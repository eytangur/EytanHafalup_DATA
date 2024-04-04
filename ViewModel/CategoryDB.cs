using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryDB : BaseDB
    { 
        protected override BaseEntity NewEntity()
        {
           return new Category();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Category category = entity as Category;
            category.Id = int.Parse(reader["id"].ToString());
            category.CategoryName = reader["category"].ToString();
            return category;   
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Category category = entity as Category;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@category", category.CategoryName);
            command.Parameters.AddWithValue("@id", category.Id);
        }
        public CategoryList SelectAllCategories()
        {
            command.CommandText = "SELECT * FROM TBLcategories";
            CategoryList list = new CategoryList(ExecuteCommand());
            return list;
        }
        public Category SelectById(int id)
        {
            command.CommandText = "SELECT * FROM TBLcategories WHERE id=" + id;
            CategoryList list = new CategoryList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Category category)
        {
            command.CommandText = "INSERT INTO TBLcategories (category) VALUES (@category)";
            LoadParameters(category);
            return ExecuteCRUD();
        }
        public int Update(Category category)
        {
            command.CommandText = "UPDATE TBLcategories " +
                "SET  category = @category " +
                "WHERE  (id = @id)";
            LoadParameters(category);
            return ExecuteCRUD();
        }
        public int Delete(Category category)
        {
            command.CommandText = $"DELETE FROM TBLcategories WHERE (TBLcategories.id = {category.Id})";
            return ExecuteCRUD();
        }

    }
}
