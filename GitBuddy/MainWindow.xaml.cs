using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using LibGit2Sharp;

namespace GitBuddy;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
[ObservableObject]
public partial class MainWindow : Window
{
    [ObservableProperty]
    ObservableCollection<RepositoryViewModel> _repositories = new();

    [ObservableProperty]
    BranchViewModel _selectedBranch;

    public MainWindow()
    {
        InitializeComponent();

        DataContext = this;

        Repository repository = new("D:\\BattleForce2249.Unity");
        RepositoryViewModel viewModel = new RepositoryViewModel(new RepositoryModel(repository));

        _repositories.Add(viewModel);

        SelectedBranch = viewModel.LocalBranches.Branches[0];
    }
}
