using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using MunicipalServicesAppPoe3.Models;

namespace MunicipalServicesAppPoe3.Services
{
    public static class IssueManager
    {
        private static readonly string FilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "issues.json");

        public static List<IssueReport> Issues = new List<IssueReport>();

        static IssueManager()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            LoadIssues();
        }

        public static void AddIssue(IssueReport issue)
        {
            issue.Id = Issues.Count > 0 ? Issues.Max(i => i.Id) + 1 : 1;
            Issues.Add(issue);
            SaveIssues();
        }

        public static void UpdateStatus(int id, string newStatus)
        {
            var issue = Issues.FirstOrDefault(i => i.Id == id);
            if (issue != null)
            {
                issue.Status = newStatus;
                SaveIssues();
            }
        }

        public static void SaveIssues()
        {
            var json = JsonConvert.SerializeObject(Issues, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static void LoadIssues()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                Issues = JsonConvert.DeserializeObject<List<IssueReport>>(json) ?? new List<IssueReport>();
            }
        }

        public static List<IssueReport> GetIssuesSorted()
        {
            return Issues.OrderByDescending(i => i.Id).ToList();
        }
    }
}
