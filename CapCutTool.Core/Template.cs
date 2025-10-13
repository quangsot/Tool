using CapCutTool.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCutTool.Core
{
    public record Template<T>(T Example, ICollection<T> Container)
    : ITemplate
    where T : Base, new()
    {
        public T Copy()
        {
            //TODO - make all cloneable
            T result = typeof(ICloneable<T>).IsAssignableFrom(typeof(T))
                ? ((ICloneable<T>)Example).DeepCopy()
                : new();

            result.Id = Guid.NewGuid();
            result.TemplateId = Example.Id;
            Container.Add(result);
            return result;
        }

        public void Detach()
        {
            Container.Remove(Example);
        }
    }

    public interface ITemplate
    {
        void Detach();
    }

    public interface ICloneable<T>
    {
        T DeepCopy();
    }
}
