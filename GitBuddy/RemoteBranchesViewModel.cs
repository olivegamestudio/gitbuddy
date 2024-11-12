using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GitBuddy;

/// <summary>
/// Represents the view model for remote Git branches.
/// </summary>
public partial class RemoteBranchesViewModel : ObservableObject
{
    /// <summary>
    /// Gets or sets the collection of remote branch view models.
    /// </summary>
    [ObservableProperty]
    ObservableCollection<BranchViewModel> _branches = new();
}
