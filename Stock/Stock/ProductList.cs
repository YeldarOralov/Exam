using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Stock
{
    public delegate void Add(string text);
    public class ProductList<T>:IRepository<T>
    {
        public event Add ProductAdded;

        public void Add(T entity)
        {
            ProductAdded($"Товар добавлен");
            var data = GetAll();
            data.Add(entity);
            using (StreamWriter stream = File.CreateText("productlist.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(stream, data);
            }
        }

        public void Delete(T entity)
        {
            ProductAdded($"Товар удален");
            var data = GetAll();
            data.Remove(entity);
            using (StreamWriter stream = File.CreateText("productlist.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(stream, data);
            }
        }

        public List<T> GetAll()
        {
            try
            {
                using (StreamReader stream = File.OpenText("productlist.json"))
                {
                    if (stream.Peek() < 0)
                    {
                        return new List<T>();
                    }
                    JsonSerializer serializer = new JsonSerializer();
                    return (List<T>)serializer.Deserialize(stream, typeof(List<T>));
                }                
            }
            catch (FileNotFoundException)
            {
                File.CreateText("productlist.json").Close();
                return new List<T>();
            }
        }
    }
}
