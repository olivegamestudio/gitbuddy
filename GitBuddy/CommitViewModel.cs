using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GitBuddy;

/// <summary>
/// Represents the view model for a Git commit.
/// </summary>
public partial class CommitViewModel : ObservableObject
{
    readonly CommitModel _model;

    /// <summary>
    /// Gets or sets the commit message.
    /// </summary>
    [ObservableProperty]
    string _message = string.Empty;

    /// <summary>
    /// Gets or sets the commit hash.
    /// </summary>
    [ObservableProperty]
    string _hash = string.Empty;

    /// <summary>
    /// Gets or sets the author of the commit.
    /// </summary>
    [ObservableProperty]
    string _author = string.Empty;

    /// <summary>
    /// Gets or sets the commit date as a string.
    /// </summary>
    [ObservableProperty]
    string _commitDate = string.Empty;

    /// <summary>
    /// Gets or sets the collection of tags associated with the commit.
    /// </summary>
    [ObservableProperty]
    ObservableCollection<TagViewModel> _tags = new();

    /// <summary>
    /// Gets or sets the collection of branches associated with the commit.
    /// </summary>
    [ObservableProperty]
    ObservableCollection<BranchViewModel> _branches = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="CommitViewModel"/> class.
    /// </summary>
    /// <param name="model">The commit model.</param>
    public CommitViewModel(CommitModel model)
    {
        _model = model;
        Message = model.Message;
        Hash = model.HashString;
        Author = model.Author;
        CommitDate = model.CommitDate.ToString();
        UpdateTags();
        UpdateBranches();
    }

    /// <summary>
    /// Updates the tags associated with the commit.
    /// </summary>
    public void UpdateTags()
    {
        Tags.Clear();
        foreach (TagModel tag in _model.Tags)
        {
            Tags.Add(new TagViewModel(tag));
        }
    }

    /// <summary>
    /// Updates the branches associated with the commit.
    /// </summary>
    public void UpdateBranches()
    {
        Branches.Clear();
        foreach (BranchModel branch in _model.Branches)
        {
            Branches.Add(new BranchViewModel(branch));
        }
    }
}
