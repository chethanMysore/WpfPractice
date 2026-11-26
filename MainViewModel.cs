using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

public class MainViewModel : INotifyPropertyChanged
{
    private string _userName = string.Empty;

    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            OnPropertyChanged();
        }
    }

    public ICommand GreetCommand { get; }

    public MainViewModel()
    {
        GreetCommand = new RelayCommand(ExecuteGreet, CanExecuteGreet);
    }

    // Execute only when text box is empty
    private bool CanExecuteGreet(object? parameter)
    {
        return !string.IsNullOrWhiteSpace(UserName);
    }

    // Actual execution logic
    private void ExecuteGreet(object? parameter)
    {
        string role = parameter?.ToString() ?? "User";
        MessageBox.Show($"Hello, {UserName}! (Role: {role})");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
