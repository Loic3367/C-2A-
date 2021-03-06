﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class Steps
    {
        public long Number { get; set; }
        public string Description { get; set; }
    }

    public class StepViewModel : ViewModelBase
    {
        string description;
        public string Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
                this.NotifyPropertyChanged();
            }
        }
        public long Num { get; }
        public StepViewModel(long num)
        {
            this.Num = num;
        }
    }
    public class AddStepsViewModel : ViewModelBase
    {
        public ObservableCollection<StepViewModel> Steps { get; }
            = new ObservableCollection<StepViewModel>();
        RecipeViewModel current;
        ObservableCollection<RecipeViewModel> allRecipies;
        public AddStepsViewModel(RecipeViewModel current, ObservableCollection<RecipeViewModel> allRecipies)
        {
            this.current = current;
            this.allRecipies = allRecipies;
            //At least one by default.
            this.AddEmpty();
        }
        public void AddEmpty()
        {
            this.Steps.Add(new StepViewModel(this.Steps.Count+1));
        }
        public void RemoveLast()
        {
            this.Steps.RemoveAt(this.Steps.Count - 1);
        }
        public void SendToBDD()
        {
            var toInsert = this.current;
            toInsert.ListSteps = this.Steps
                .Select(svm => new Steps()
                {
                    Description = svm.Description,
                    Number = svm.Num
                })
                .ToList();
            toInsert.CreatorId = Profil.CurrentProfil.ID;
            toInsert.ID = DataAccess.Dal.InsertRecipe(toInsert);
            
            foreach (IngredientViewModel i in toInsert.ListIngredients)
            {
                DataAccess.Dal.InsertListIngredients(toInsert.ID, i);
            }
            foreach(Steps r in toInsert.ListSteps)
            {
                DataAccess.Dal.InsertSteps(toInsert.ID, r);
            }
            allRecipies.Add(toInsert);
            MessageBox.Show("La recette a été correctement importée dans la BDD");
        }
    }
}
