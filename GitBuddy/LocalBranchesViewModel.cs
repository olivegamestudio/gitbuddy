using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GitBuddy;

/// <summary>
/// Represents the view model for local Git branches.
/// </summary>
public partial class LocalBranchesViewModel : ObservableObject
{
    /// <summary>
    /// Gets or sets the collection of local branch view models.
    /// </summary>
    [ObservableProperty]
    ObservableCollection<BranchViewModel> _branches = new();
}
