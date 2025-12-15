using System;
using System.IO;
using EtudiantOS.Models;
using Newtonsoft.Json;

namespace EtudiantOS.Services
{
    public class BudgetService
    {
        private const string SystemFolder = "_System";
        private const string BudgetFile = "budget.json";

        public BudgetModel LoadBudget(string vaultPath)
        {
            var path = Path.Combine(vaultPath, SystemFolder, BudgetFile);
            if (!File.Exists(path)) return new BudgetModel();

            try
            {
                var json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<BudgetModel>(json) ?? new BudgetModel();
            }
            catch
            {
                return new BudgetModel();
            }
        }

        public void SaveBudget(string vaultPath, BudgetModel budget)
        {
            var systemPath = Path.Combine(vaultPath, SystemFolder);
            if (!Directory.Exists(systemPath))
            {
                Directory.CreateDirectory(systemPath);
            }

            var path = Path.Combine(systemPath, BudgetFile);
            var json = JsonConvert.SerializeObject(budget, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
