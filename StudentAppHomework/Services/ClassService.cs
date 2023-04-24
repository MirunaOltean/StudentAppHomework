using Core.Services;
using StudentAppHomework.DBContext;
using StudentAppHomework.Models;

namespace StudentAppHomework.Services
{
    public class ClassService : IClassService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly AuthorizationService authorizationService;


        public ClassService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            _unitOfWork = unitOfWork;
            authorizationService = authService;
        }

        public Task<bool> Create(Class model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Class> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Class>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, Class model)
        {
            throw new NotImplementedException();
        }


        //public async Task<bool> Create(PostDTO model)
        //{
        //    Post post = new()
        //    {
        //        Content = model.Content,
        //        AuthorId = model.AuthorId,
        //        TimeStamp = DateOnly.FromDateTime(model.TimeStamp)
        //    };
        //    await _postRepository.AddPost(post);
        //    return true;
        //}

        //public async Task<bool> Delete(int id)
        //{
        //    var post = await _postRepository.GetPostById(id);

        //    if (post == null)
        //    {
        //        return false;
        //    }
        //    await _postRepository.DeletePost(post);
        //    return true;
        //}

        //public async Task<PostDTO> Get(int id)
        //{
        //    return (await _postRepository.GetPostById(id)).ToPostDTO();
        //}

        //public async Task<List<PostDTO>> GetAll()
        //{
        //    return (await _postRepository.GetAllPosts()).ToPostsDTO();
        //}

        //public async Task<List<CommentDTO>> GetAllCommentsForPost(int postId)
        //{
        //    return (await _postRepository.GetAllCommentsForPost(postId)).ToCommentsDTO();
        //}

        //public async Task<bool> Update(int id, PostDTO model)
        //{
        //    var post = await _postRepository.GetPostById(id);

        //    if (post == null)
        //    {
        //        return false;
        //    }

        //    post.Content = model.Content;
        //    await _postRepository.UpdatePost(post);

        //    return true;
        //}
    }
}
