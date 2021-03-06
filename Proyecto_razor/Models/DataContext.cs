﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace Proyecto_razor.Models
{
    public class DataContext
    {

        public string ConnectionString { get; set; }

        public DataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public bool check(string email, string contrasena)
        {
            using(MySqlConnection conn= GetConnection())
            {
                conn.Open();
                bool success = false;
                MySqlCommand cmd=new MySqlCommand("SELECT COUNT(*) FROM usuarios WHERE email='"+email+"' AND contrasena='"+contrasena+"'", conn);
                using(MySqlDataReader reader= cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        success = true;
                    }
                }
                return success;
            }
        }
        public List<Producto> GetAllProducts()
        {
            List<Producto> lista_productos = new List<Producto>();
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT id, nombre, precio, cantidad, foto FROM productos ", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista_productos.Add(new Producto()
                        {
                            id = reader.GetInt32("id"),
                            nombre = reader.GetString("nombre"),
                            cantidad = reader.GetInt32("cantidad"),
                            precio = reader.GetDouble("precio"),
                            //Status = reader.GetBoolean("Status"),
                            foto = reader.GetString("foto")
                        });
                    }
                }
            }
            return lista_productos;
        }
        public List<Users> GetAllUsers()
        {
            List<Users> lista_usuarios = new List<Users>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios ", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista_usuarios.Add(new Users()
                        {
                            id = reader.GetInt32("id"),
                            nombre = reader.GetString("nombre"),
                            apellidos = reader.GetString("apellidos"),
                            email = reader.GetString("email"),
                            password = reader.GetString("password")
                        });
                    }
                }
            }
            return lista_usuarios;
        }
        //INSERTAR USUARIOS
        public void add(Users user)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO usuarios (nombre, apellidos, email, contrasena) VALUES ('" +
                             user.nombre + "', '" + user.apellidos + "', '" + user.email + "', '" + user.password + "');", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    }
                    conn.Close();
                }
            }
        }
    }
}