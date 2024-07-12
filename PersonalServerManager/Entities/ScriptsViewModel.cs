using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalServerManager.Entities
{
    public class ScriptsViewModel : ViewModelBase
    {
        public ObservableCollection<ScriptViewModel> Scripts { get; } = new ObservableCollection<ScriptViewModel>();

        private ScriptViewModel _selectedScript;
        public ScriptViewModel SelectedScript
        {
            get => _selectedScript;
            set
            {
                _selectedScript = value;
                OnPropertyChanged(nameof(SelectedScript));
            }
        }

        public ICommand NewScriptCommand { get; }
        public ICommand DeleteScriptCommand { get; }
        public ICommand ExecuteCommand { get; }

        public ScriptsViewModel()
        {
            //// Populate the Scripts collection with dummy scripts
            //for (int i = 1; i <= 10; i++)
            //{
            //    Scripts.Add(new ScriptViewModel
            //    {
            //        Name = $"Script {i}",
            //        Content = $"Content of Script {i}"
            //    });
            //}

            NewScriptCommand = new RelayCommand(NewScript);
            DeleteScriptCommand = new RelayCommand(DeleteScript, CanDeleteScript);
            ExecuteCommand = new RelayCommand(Execute, CanExecute);

        }

        private void NewScript(object parameter)
        {
            // Implement logic to create a new script
        }

        private void DeleteScript(object parameter)
        {
            // Implement logic to delete the selected script
        }

        private bool CanDeleteScript(object parameter)
        {
            // Implement logic to determine if a script can be deleted
            return SelectedScript != null;
        }

        private void Execute(object parameter)
        {
            // Implement logic to execute the command
        }

        private bool CanExecute(object parameter)
        {
            // Implement logic to determine if the command can be executed
            return SelectedScript != null;
        }
    }

    public class ScriptViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
        // Other properties and methods for the ScriptViewModel
    }
}
