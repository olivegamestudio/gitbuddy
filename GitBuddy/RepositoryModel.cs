using LibGit2Sharp;

namespace GitBuddy;

/// <summary>
/// Represents a Git repository model.
/// </summary>
public class RepositoryModel
{
    readonly Repository _repository;

    /// <summary>
    /// Gets the name of the repository.
    /// </summary>
    public string Name => _repository.Info.WorkingDirectory;

    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryModel"/> class.
    /// </summary>
    /// <param name="repository">The Git repository.</param>
    public RepositoryModel(Repository repository)
    {
        _repository = repository;
        _branches = _repository.Branches.Select(branch => new BranchModel(branch)).ToList();
    }

    private List<BranchModel> _branches = new();

    /// <summary>
    /// Gets the branches in the repository.
    /// </summary>
    public IEnumerable<BranchModel> Branches => _branches;

    /// <summary>
    /// Gets the tags in the repository.
    /// </summary>
    public IEnumerable<TagModel> Tags => _repository.Tags.Select(tag => new TagModel(tag));
}
