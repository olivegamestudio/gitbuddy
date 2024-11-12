using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GitBuddy;

/// <summary>
/// Represents the view model for a Git repository.
/// </summary>
public partial class RepositoryViewModel : ObservableObject
{
    readonly RepositoryModel _model;

    /// <summary>
    /// Gets or sets the view model for local branches.
    /// </summary>
    [ObservableProperty]
    LocalBranchesViewModel _localBranches = new();

    /// <summary>
    /// Gets or sets the view model for remote branches.
    /// </summary>
    [ObservableProperty]
    RemoteBranchesViewModel _remoteBranches = new();

    /// <summary>
    /// Gets or sets the collection of root items in the repository.
    /// </summary>
    [ObservableProperty]
    ObservableCollection<ObservableObject> _rootItems = new();

    /// <summary>
    /// Gets or sets the name of the repository.
    /// </summary>
    [ObservableProperty]
    string name;

    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryViewModel"/> class.
    /// </summary>
    /// <param name="repository">The repository model.</param>
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
            model.UpdateTags(repository.Tags);
            BranchViewModel branch = new(model);

            if (model.IsRemote)
            {
                RemoteBranches.Branches.Add(branch);
            }
            else
            {
                LocalBranches.Branches.Add(branch);
            }
        }
    }
}
