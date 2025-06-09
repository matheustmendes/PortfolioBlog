namespace BlogPortfolio;

public class PostService
{
    List<Post> posts = new List<Post>();

    public void AddPost(Post post)
    {
        if (post == null)
        {
            throw new ArgumentNullException(nameof(post), "Post cannot be null");
        }

        post.Id = posts.Count + 1; // Simple ID assignment
        posts.Add(post);
    }

    public List<Post> GetAllPosts()
    {
        return posts; 
    }
    
    public void RemovePost(int id) 
    {
        var post = posts.FirstOrDefault(p => p.Id == id);
        if (post != null)
        {
            posts.Remove(post);
        }
        else
        {
            throw new KeyNotFoundException($"Post with ID {id} not found.");
        }
    }
    
    // talvez implementar depois um getpostbyid 
    
    // metodo para editar post:
    
    // Um método não pode ter seu id atualizado, nem seu autor modificado.

    public void UpdatePost(int id, Post UpdatedPost)
    {
        if (UpdatedPost == null)
        {
            throw new ArgumentNullException(nameof(UpdatedPost), "Post cannot be null");
        }

        var post = posts.FirstOrDefault((p) => p.Id == id);
        if (post == null)
        {
            throw new KeyNotFoundException($"Post with ID {id} not found.");
        }
        
        post.Title = UpdatedPost.Title;
        post.Content = UpdatedPost.Content;
        post.UpdatedAt = DateTime.Now;
    }
}