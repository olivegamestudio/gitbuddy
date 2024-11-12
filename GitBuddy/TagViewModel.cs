using CommunityToolkit.Mvvm.ComponentModel;

namespace GitBuddy;

/// <summary>
/// Represents the view model for a Git tag.
/// </summary>
public partial class TagViewModel : ObservableObject
{
    readonly TagModel _model;

    /// <summary>
    /// Gets or sets the name of the tag.
    /// </summary>
    [ObservableProperty]
    string _name;

    /// <summary>
    /// Initializes a new instance of the <see cref="TagViewModel"/> class.
    /// </summary>
    /// <param name="model">The tag model.</param>
    public TagViewModel(TagModel model)
    {
        _model = model;
        Name = model.Name;
    }
}
