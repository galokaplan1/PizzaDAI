using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Pizzas.API.Utils;
using Pizzas.API.Helpers;
using Pizzas.API.Controllers;
using System.Data.SqlClient;
using Dapper;

namespace Pizzas.API.Services
{
    public class BD{
       public static Pizza Select(int id){
            Pizza UnaPizza=null;
            string sql="Select * From Pizzas where id=@iid";
            using (SqlConnection DB= new SqlConnection(BD.getConnection)){
                UnaPizza=DB.QueryFirstOrDefault<Pizza>(sql, new {iid=id});
            }
            return UnaPizza;   
        }

        public static void Delete(int id){
            string sql="Delete From Pizzas where id=@iid";
            using (SqlConnection DB= new SqlConnection(BD.getConnection)){
                DB.Execute(sql, new {iid=id});
            }   
        }

        public static int Insert( Pizza insertarPizza){
            int insertado=0;
            string sql="Insert Into Pizzas (Nombre, LibreGluten, Importe, Descripcion) Values (@Nnombre, @Gluten, @Iimporte, @descrip)";
            using (SqlConnection DB= new SqlConnection(BD.getConnection)){
                insertado=DB.Execute(sql, new {Nnombre=insertarPizza.Nombre, Gluten=insertarPizza.LibreGluten, Iimporte=insertarPizza.Importe, descrip=insertarPizza.Descripcion});
            }   
            return insertado;
        }

        public static int Update(Pizza PizzaACambiar){
            int cambiado=0;
            string sql="Update Pizzas Set Nombre=@name, LibreGluten=@glut, Importe=@Iimporte, Descripcion=@descrip where id=@Iid";
            using (SqlConnection DB= new SqlConnection(BD.getConnection)){
                cambiado=DB.Execute(sql, new {iid=PizzaACambiar.Id, name=PizzaACambiar.Nombre, glut=PizzaACambiar.LibreGluten, Iimporte=PizzaACambiar.Importe, descrip=PizzaACambiar.Descripcion});
            }
            return cambiado;   
        }

        public static List<Pizza> SelectAll(){
            List<Pizza> pizzas= new List<Pizza>();
            string sql="Select * From Pizzas";
            using (SqlConnection DB= new SqlConnection(BD.getConnection)){
                pizzas=DB.Query<Pizza>(sql).ToList();
            } 
            return pizzas;  
        }
    }
    
}