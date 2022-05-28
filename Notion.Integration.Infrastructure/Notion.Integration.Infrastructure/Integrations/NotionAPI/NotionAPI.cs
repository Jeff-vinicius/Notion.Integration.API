using Flurl.Http;
using Flurl;
using System.Text.Json;
using Notion.Integration.Infrastructure.Integrations.NotionAPI.Models;
using Notion.Integration.Domain.Models;

namespace Notion.Integration.Infrastructure.Integrations.NotionAPI
{
    public class NotionAPI
    {
        private const string URL_BASE = "https://api.notion.com/v1/";

        public async Task<UserNotion> CreateUserPage(UserNotion user)
        {

            var request = new PageRequest();
            request.AddParentPageId(user.PageNotion.PageParentId);
            AddUserInfos(user, request);
            AddTasks(user, request);
            AddPostsAndComments(user, request);
            AddStatistics(user, request);

            var data = JsonSerializer.Serialize(request);

            SavePayload(data, "UserPage");

            try
            {
                var response = await URL_BASE
                    .WithTimeout(TimeSpan.FromSeconds(25))
                    .AppendPathSegment("pages")
                    .WithHeader("Content-Type", "application/json")
                    .WithHeader("Authorization", $"Bearer {user.PageNotion.Authorization}")
                    .WithHeader("Notion-Version", "2022-02-22")
                    .PostStringAsync(data)
                    .ReceiveString();

                var responsePage = JsonSerializer.Deserialize<PageResponse>(response);

                user.PageNotion.PageUserId = responsePage.PageId;
                user.PageNotion.PageUrl = responsePage.PageUrl;

                return user;
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new Exception("Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();

                throw new Exception(message, ex);
            }
        }

        public async Task<ManagerNotion> CreateManagerPage(List<UserNotion> users, ManagerNotion manager)
        {

            var request = new PageRequest();
            request.AddParentPageId(users.FirstOrDefault().PageNotion.PageParentId);
            AddManagerInfos(manager, request);
            AddManagerStatistics(users, request);

            var data = JsonSerializer.Serialize(request);

            SavePayload(data, "ManagerPage");

            try
            {
                var response = await URL_BASE
                    .WithTimeout(TimeSpan.FromSeconds(25))
                    .AppendPathSegment("pages")
                    .WithHeader("Content-Type", "application/json")
                    .WithHeader("Authorization", $"Bearer {users.FirstOrDefault().PageNotion.Authorization}")
                    .WithHeader("Notion-Version", "2022-02-22")
                    .PostStringAsync(data)
                    .ReceiveString();

                var responsePage = JsonSerializer.Deserialize<PageResponse>(response);

                manager.PageManageUrl = responsePage.PageUrl;

                return manager;
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new Exception("Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var message = await ex.GetResponseStringAsync();

                throw new Exception(message, ex);
            }
        }

        #region Private Methods
        private static void AddUserInfos(UserNotion user, PageRequest request)
        {
            request.AddPropertieTitle($"👾 {user.Name}");
            request.AddChild("heading_1", "📋 Informações", null, null, null);
            request.AddChild("paragraph", $"☎️ {user.Phone}", null, null, null);
            request.AddChild("paragraph", $"📧 {user.Email}", null, null, null);
            request.AddChild("paragraph", $"💼 {user.Company}", null, null, null);
            request.AddChild("paragraph", $"🏚 {user.City}", null, null, null);
            request.AddChild("divider", null, null, null, null);
        }

        private static void AddTasks(UserNotion user, PageRequest request)
        {
            request.AddChild("heading_1", "📌 Tarefas", null, null, null);

            if (user.Tasks.Count > 0)
            {
                foreach (var task in user.Tasks)
                {
                    request.AddChild("to_do", task.Title, task.Completed, null, null);
                }
            }
            else
            {
                request.AddChild("paragraph", "❗ Este Usuário não possui tarefas cadastradas.", null, null, null);
            }

            request.AddChild("divider", null, null, null, null);
        }

        private static void AddPostsAndComments(UserNotion user, PageRequest request)
        {
            request.AddChild("heading_1", "📝 Publicações", null, null, null);
            request.AddChild("paragraph", "▶️ Visualizar comentários.", null, null, null);

            if (user.Posts.Count > 0)
            {
                foreach (var post in user.Posts)
                {
                    List<ChildComments> childComments = new();

                    if (post.Comments.Count > 0)
                    {
                        foreach (var comment in post.Comments)
                        {
                            childComments.Add(new ChildComments()
                            {
                                Type = "bulleted_list_item",
                                BulletedListItem = new BulletedListItem(comment.Title)
                            });
                        }

                        request.AddChild("toggle", post.Title, null, childComments, null);
                    }
                    else
                    {
                        request.AddChild("toggle", post.Title, null, childComments, null);
                        request.AddChild("paragraph", "❗ Esta publicação não possui comentários.", null, null, null);
                    }
                }
            }
            else
            {
                request.AddChild("paragraph", "❗ Este Usuário não possui publicações cadastradas.", null, null, null);
            }

            request.AddChild("divider", null, null, null, null);
        }

        public static void AddStatistics(UserNotion user, PageRequest request)
        {
            request.AddChild("heading_1", "📊 Estatísticas ", null, null, null);

            List<Cells> cellsHeader = new()
            {
                new Cells("Publicações"),
                new Cells("Comentários"),
                new Cells("Tarefas Concluídas"),
                new Cells("Tarefas Pendentes")
            };

            List<Cells> cellsContet = new()
            {
                new Cells(user.Statistics.TotalPosts),
                new Cells(user.Statistics.TotalComments),
                new Cells(user.Statistics.TotalTasksCompleted),
                new Cells(user.Statistics.TotalTasksPending)
            };

            TableRow header = new(cellsHeader);
            TableRow content = new(cellsContet);

            List<ChildTable> childTable = new();
            childTable.Add(new ChildTable()
            {
                TableRow = header,
            });
            childTable.Add(new ChildTable()
            {
                TableRow = content,
            });

            request.AddChild("table", null, null, null, childTable);
        }

        private static void SavePayload(string jsonResult, string fileName)
        {
            string path = @$"c:\temp\{fileName}.txt";

            if (!File.Exists(path))
            {
                using var tw = new StreamWriter(path, true);
                tw.WriteLine(jsonResult.ToString());
                tw.Close();
            }
            else
            {
                File.Delete(path);
                using var tw = new StreamWriter(path, true);
                tw.WriteLine(jsonResult.ToString());
                tw.Close();
            }
        }
        #endregion

        private static void AddManagerInfos(ManagerNotion manager, PageRequest request)
        {
            request.AddPropertieTitle($"Olá 🤖 {manager.ManagerName}");
            request.AddChild("heading_1", "📋 Informações Gerais", null, null, null);
            request.AddChild("paragraph", $"🖱 Clicando no nome do usuário, você pode acessar informações detalhadas!",
                null, null, null);
            request.AddChild("paragraph", $"🏆 Os usuários estão ordenados de acordo com o maior número de publicações!",
                null, null, null);
        }

        public static void AddManagerStatistics(List<UserNotion> users, PageRequest request)
        {
            List<ChildTable> childTable = new();
            
            List<Cells> cellsHeader = new()
            {
                new Cells("Nome"),
                new Cells("Publicações"),
                new Cells("Tarefas Concluídas"),
                new Cells("Tarefas Pendentes")
            };

            TableRow header = new(cellsHeader);
            childTable.Add(new ChildTable()
            {
                TableRow = header,
            });

           
            List<TableRow> tableRowList = new();

            foreach (var user in users)
            {
                List<Cells> cellsContet = new();

                cellsContet.Add(new Cells(user.Name));
                cellsContet.Add(new Cells(user.Statistics.TotalPosts));
                cellsContet.Add(new Cells(user.Statistics.TotalTasksCompleted));
                cellsContet.Add(new Cells(user.Statistics.TotalTasksPending));

                tableRowList.Add(new TableRow(cellsContet));
            }

            foreach (var tableRow in tableRowList)
            {
                childTable.Add(new ChildTable()
                {
                    TableRow = tableRow,
                });
            }

            request.AddChild("table", null, null, null, childTable);
        }
    }
}
