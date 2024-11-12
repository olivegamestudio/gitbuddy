using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using LibGit2Sharp;

namespace GitBuddy;

public class BranchModel
{
    readonly Branch _branch;

    public string Name => _branch.FriendlyName;

    public bool IsRemote => _branch.IsRemote;

    public List<CommitModel> Commits { get; set; } = new();

    public BranchModel(Branch branch)
    {
        _branch = branch;

        foreach (Commit c in branch.Commits)
        {
            Commits.Add(new CommitModel(c));
        }
    }
}

public class CommitModel
{
    readonly Commit _commit;

    public string Message { get; set; }

    public string Hash { get; set; }

    public CommitModel(Commit commit)
    {
        _commit = commit;
        Message = commit.Message;
        Hash = commit.Sha;
    }
}

public partial class CommitViewModel : ObservableObject
{
    readonly CommitModel _model;

    [ObservableProperty]
    string _message = string.Empty;

    [ObservableProperty]
    string _hash = string.Empty;

    public CommitViewModel(CommitModel model)
    {
        _model = model;
        Message = model.Message;
        Hash = model.Hash;
    }
}

public partial class BranchViewModel : ObservableObject
{
    readonly BranchModel _model;

    [ObservableProperty]
    string _name;

    [ObservableProperty]
    bool _isRemote;

    [ObservableProperty]
    ObservableCollection<CommitViewModel> _commits = new();

    public BranchViewModel(BranchModel model)
    {
        _model = model;

        Name = model.Name;
        IsRemote = model.IsRemote;

        foreach (CommitModel commit in model.Commits)
        {
            Commits.Add(new CommitViewModel(commit));
        }
    }
}

public class RepositoryModel
{
    readonly Repository _repository;

    public string Name => _repository.Info.WorkingDirectory;

    public RepositoryModel(Repository repository)
    {
        _repository = repository;
    }

    public List<BranchModel> Branches
    {
        get
        {
            List<BranchModel> branches = new();
            foreach (Branch b in _repository.Branches)
            {
                branches.Add(new BranchModel(b));
            }
            return branches;
        }
    }
}

public partial class RepositoryViewModel : ObservableObject
{
    readonly RepositoryModel _model;

    [ObservableProperty]
    LocalBranchesViewModel _localBranches = new();

    [ObservableProperty]
    RemoteBranchesViewModel _remoteBranches = new();

    [ObservableProperty]
    ObservableCollection<ObservableObject> _rootItems = new();

    [ObservableProperty]
    string name;

    public RepositoryViewModel(RepositoryModel repository)
    {
        _model = repository;
        Name = repository.Name;

        _rootItems.Add(LocalBranches);
        _rootItems.Add(RemoteBranches);

        LocalBranches.Branches.Clear();
        RemoteBranches.Branches.Clear();

        foreach (BranchModel model in repository.Branches)
        {
            if (model.IsRemote)
            {
                RemoteBranches.Branches.Add(new BranchViewModel(model));
                continue;
            }

            LocalBranches.Branches.Add(new BranchViewModel(model));
        }
    }
}

public partial class LocalBranchesViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<BranchViewModel> _branches = new();
}

public partial class RemoteBranchesViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<BranchViewModel> _branches = new();
}

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

        Repository repository = new("D:\\Common.Unity");
        RepositoryViewModel viewModel = new RepositoryViewModel(new RepositoryModel(repository));

        _repositories.Add(viewModel);

        SelectedBranch = viewModel.LocalBranches.Branches[0];
    }
}
