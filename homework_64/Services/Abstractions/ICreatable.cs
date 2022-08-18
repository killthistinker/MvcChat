using System.Threading.Tasks;

namespace homework_64.Services.Abstractions
{
    public interface  ICreatable<in T> where T : class
    {
        public Task CreateAsync(T entity, string userName);
    }
}