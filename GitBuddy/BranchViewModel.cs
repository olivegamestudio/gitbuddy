using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GitBuddy;

/// <summary>
/// Represents the view model for a Git branch.
/// </summary>
public partial class BranchViewModel : ObservableObject
{
    readonly BranchModel _model;

    /// <summary>
    /// Gets or sets the name of the branch.
    /// </summary>
    [ObservableProperty]
    string _name;

    /// <summary>
    /// Gets or sets a value indicating whether the branch is remote.
    /// </summary>
    [ObservableProperty]
    bool _isRemote;

    /// <summary>
    /// Gets or sets the collection of commits in the branch.
    /// </summary>
    [ObservableProperty]
    ObservableCollection<CommitViewModel> _commits = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="BranchViewModel"/> class.
    /// </summary>
    /// <param name="model">The branch model.</param>
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
