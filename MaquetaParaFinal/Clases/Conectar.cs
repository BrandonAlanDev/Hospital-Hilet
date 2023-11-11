using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows;
using Newtonsoft.Json.Bson;
using MaquetaParaFinal.View;

namespace MaquetaParaFinal.Clases
{
    class Conectar
    {
        string contrasenia = "workstation id=SegundoCuatriTp1.mssql.somee.com;packet size=4096;user id=Lucho_SQLLogin_2;pwd=66e99i24sw;data " +
            "source=SegundoCuatriTp1.mssql.somee.com;persist security info=False;initial catalog=SegundoCuatriTp1";

        public DataTable DescargarTablaServicios()
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                conexion.Open();
                string consulta = "SELECT Nombre_Servicio AS Servicio FROM Servicios " +
                                    "WHERE (Fecha_Baja IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }
        public DataTable DescargarTablaEspecialidades()
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                conexion.Open();
                string consulta = "SELECT Nombre_Especialidad AS Especialidad FROM Especialidades " +
                                    "WHERE (Fecha_Baja IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable DescargarTablaLocalidades()
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                conexion.Open();
                string consulta = "SELECT DISTINCT Nombre_Localidad AS Localidad FROM Localidades " +
                                    "WHERE (Fecha_Baja IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }
        public DataTable DescargarTablaCodPostal(object Localidad)
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                conexion.Open();
                string consulta = $"SELECT Codigo_Postal AS CodPostal FROM Localidades WHERE Nombre_Localidad = '{Localidad}' AND " +
                                    $"(Fecha_Baja IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable DescargaTablaEspecialidades()
        {
            using(SqlConnection conexion = new SqlConnection (contrasenia)) 
            {
                conexion.Open ();
                string consulta = "SELECT Nombre_Especialidad AS Especialidad FROM Especialidades " +
                                    "WHERE (Fecha_Baja IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter (consulta,conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable DescargaTablaTiposDeMuestra() 
        {
            using(SqlConnection conexion = new SqlConnection (contrasenia))
            {
                conexion.Open ();
                string consulta = "SELECT Nombre_Tipo_De_Muestra AS 'Tipo de Muestra' FROM TiposDeMuestras " +
                                    "WHERE (Fecha_Baja IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable DescargaTablaCategorias() 
        {
            using( SqlConnection conexion = new SqlConnection (contrasenia))
            {
                conexion.Open();
                string consulta = "SELECT Nombre_Categoria AS Categoria FROM Categorias " +
                                    "WHERE (Fecha_Baja IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter ( consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }
        
        public DataTable DescargaTablaPaciente() //Anda
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                conexion.Open();
                string consulta = "SELECT " +
                        "p.Pk_Id_Pacientes AS ID, " +
                        "p.Nombre_Paciente AS Nombre, " +
                        "p.Apellido_Paciente AS Apellido, " +
                        "CONVERT(varchar, p.Fecha_De_Nacimiento, 120) AS 'Fecha De Nacimiento', " +
                        "p.Dni, p.Email, p.Telefono, p.Calle, p.Numero, p.Piso, " +
                        "l.Nombre_Localidad AS Localidad, " +
                        "l.Codigo_Postal AS 'Codigo Postal' " +
                    "FROM Pacientes AS p " +
                        "INNER JOIN Localidades AS l ON p.Fk_Id_Localidades = l.Pk_Id_Localidades " +
                    "WHERE p.Baja_Pacientes IS NULL;";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable DescargaTablaProfesinales() //Anda
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                conexion.Open();
                string consulta = "SELECT " +
                    "Pk_Id_Profesionales AS ID," +
                    "Nombre_Profesional AS Nombre," +
                    "Apellido_Profesional AS Apellido,Matricula," +
                    "Nombre_Servicio AS Servicio " +
                    "FROM Profesionales " +
                        "INNER JOIN Servicios ON Fk_Id_Servicios = Pk_Id_Servicios " +
                    "WHERE (Baja_Profesional IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable DescargaTablaPersonalLaboratorio() //Probar
        {
            using(SqlConnection conexion = new SqlConnection(contrasenia))
            {
                conexion.Open();
                string consulta = "SELECT " +
                    "Pk_Id_Personal_Laboratorio AS ID," +
                    "Nombre_Personal AS Nombre," +
                    "Apellido_Personal AS Apellido," +
                    "Dni," +
                    "Nombre_Categoria AS Categoria," +
                    "Nombre_Especialidad AS Especialidad " +
                    "FROM PersonalLaboratorio " + 
                        "INNER JOIN Categorias ON Fk_Id_Categorias = Pk_Id_Categorias " +
                        "INNER JOIN Especialidades ON Fk_Id_Especialidades = Pk_Id_Especialidades " +
                    "WHERE (Baja_Personal IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable DescargaTablaPracticasXIngresos()
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = "SELECT " +
                        "pa.Nombre_Paciente, " +
                        "pa.Apellido_Paciente, " +
                        "pa.Dni, " +
                        "CONVERT(varchar,i.Fecha_Ingreso,120) AS 'Fecha De Ingreso', " +
                        "CONVERT(varchar,i.Retirado,120) AS 'Fecha De Retiro', " +
                        "pro.Nombre_Profesional, " +
                        "pro.Apellido_Profesional, " +
                        "esp.Nombre_Especialidad, " +
                        "perL.Nombre_Personal, " +
                        "perL.Apellido_Personal, " +
                        "cat.Nombre_Categoria, " +
                        "CONVERT(varchar,pra.Tiempo_Demora,120) AS 'Tiempo De Demora', " +
                        "pra.Nombre_Practica, " +
                        "tip.Nombre_Tipo_De_Muestra " +
                        "FROM PracticasxIngresos AS praxIn " +
                            "INNER JOIN Ingresos AS i ON praxIn.Fk_Id_Ingresos = i.Pk_Id_Ingresos " +
                            "INNER JOIN Pacientes AS pa ON i.Fk_Id_Paciente = pa.Pk_Id_Pacientes " +
                            "INNER JOIN Profesionales AS pro ON pro.Pk_Id_Profesionales = i.Fk_Id_Profesionales " +
                            "INNER JOIN Practicas AS pra ON praxIn.Fk_Id_Practicas = pra.Pk_Id_Practicas " +
                            "INNER JOIN Especialidades AS esp ON pra.Fk_Id_Especialidades = esp.Pk_Id_Especialidades " +
                            "INNER JOIN TiposDeMuestras AS tip ON pra.Fk_Id_Tipos_De_Muestra = tip.Pk_Id_Tipos_De_Muestra " +
                            "INNER JOIN PersonalLaboratorio AS perL ON perL.Fk_Id_Especialidades = esp.Pk_Id_Especialidades " +
                            "INNER JOIN Categorias AS cat ON perL.Fk_Id_Categorias = cat.Pk_Id_Categorias " +
                            "WHERE (pa.Baja_Pacientes IS NULL) AND (pro.Baja_Profesional IS NULL) AND (perL.Baja_Personal IS NULL);";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }
        public DataTable DescargarTablaPracticas()
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = "SELECT p.Pk_Id_Practicas AS ID, " +
                    "p.Nombre_Practica AS Nombre, " +
                    "CONVERT(varchar,p.Tiempo_Demora,120) AS 'Tiempo de Demora', " +
                    "t.Nombre_Tipo_De_Muestra AS 'Tipo De Muestra', " +
                    "e.Nombre_Especialidad AS Especialidades " +
                    "FROM Practicas AS p " +
                        "INNER JOIN TiposDeMuestras AS t ON t.Pk_Id_Tipos_De_Muestra = p.Fk_Id_Tipos_De_Muestra " +
                        "INNER JOIN Especialidades AS e ON e.Pk_Id_Especialidades = p.Fk_Id_Especialidades " +
                        "WHERE (p.Fecha_Baja IS NULL)" +
                    "ORDER BY Nombre, 'Tiempo de Demora', 'Tipo De Muestra', Especialidades;";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable DescargarPracticaDeUnIngreso(int id)
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = "SELECT  " +
                    "pxi.Pk_Id_PracticasxIngresos AS ID, " +
                    "p.Nombre_Practica AS Nombre, " +
                    "CONVERT(varchar,p.Tiempo_Demora,120) AS 'Horas de Demora', " +
                    "t.Nombre_Tipo_De_Muestra AS 'Tipo De Muestra', " +
                    "e.Nombre_Especialidad AS Especialidades " +
                    "FROM Practicas AS p " +
                        "INNER JOIN TiposDeMuestras AS t ON t.Pk_Id_Tipos_De_Muestra = p.Fk_Id_Tipos_De_Muestra " +
                        "INNER JOIN Especialidades AS e ON e.Pk_Id_Especialidades = p.Fk_Id_Especialidades " +
                        "INNER JOIN PracticasxIngresos AS pxi ON pxi.Fk_Id_Practicas = p.Pk_Id_Practicas " +
                        "INNER JOIN Ingresos AS i ON pxi.Fk_Id_Ingresos = i.Pk_Id_Ingresos " +
                        $"WHERE (p.Fecha_Baja IS NULL) AND i.Pk_Id_Ingresos = {id} " +
                    "ORDER BY Nombre, 'Horas de Demora', 'Tipo De Muestra', Especialidades;";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable DescargarTablaIngresos()
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = "SELECT i.Pk_Id_Ingresos AS ID, " +
                    "CONCAT(p.Nombre_Paciente,' ',p.Apellido_Paciente) AS Paciente, " +
                    "p.Dni, " +
                    "CONCAT(pro.Nombre_Profesional,' ',pro.Apellido_Profesional) AS Medico, " +
                    "CONVERT(varchar,i.Fecha_Ingreso, 120) AS 'Fecha De Ingreso', " +
                    "CASE WHEN CONVERT(varchar, i.Retirado, 120) = '1111-11-11' THEN NULL ELSE CONVERT(varchar, i.Retirado, 120) END AS 'Fecha De Retiro', " +
                    "COUNT(pxi.Fk_Id_Ingresos) AS Practicas " +
                    "FROM Ingresos AS i " +
                        "LEFT JOIN Profesionales AS pro ON i.Fk_Id_Profesionales = pro.Pk_Id_Profesionales " +
                        "LEFT JOIN Pacientes AS p ON p.Pk_Id_Pacientes = i.Fk_Id_Paciente " +
                        "LEFT JOIN PracticasxIngresos AS pxi ON pxi.Fk_Id_Ingresos = i.Pk_Id_Ingresos " +
                    "WHERE p.Baja_Pacientes IS NULL AND pro.Baja_Profesional IS NULL " +
                    "GROUP BY " +
                        "i.Pk_Id_Ingresos, CONCAT(p.Nombre_Paciente,' ',p.Apellido_Paciente), p.Dni, " +
                        "CONCAT(pro.Nombre_Profesional,' ',pro.Apellido_Profesional), i.Fecha_Ingreso, i.Retirado " +
                    "ORDER BY " +
                        "Paciente, Dni, Medico, 'Fecha De Ingreso', 'Fecha De Retiro';";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }

        }
        public DataTable BuscarEnTablaPacientes(string buscar)
        {
            buscar = buscar.ToLower();
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = $"SELECT Pk_Id_Pacientes AS ID, " +
                    $"Nombre_Paciente AS Nombre, " +
                    $"Apellido_Paciente AS Apellido, " +
                    $"CONVERT(varchar,Fecha_De_Nacimiento,120) AS 'Fecha De Nacimiento'," +
                    $"Dni, Email, Telefono, Calle, Numero, Piso, " +
                    $"Nombre_Localidad AS Localidad, " +
                    $"Codigo_Postal AS 'Codigo Postal' " +
                    $"FROM Pacientes INNER JOIN Localidades ON Fk_Id_Localidades=Pk_Id_Localidades " +
                        $"WHERE LOWER(Nombre_Paciente) LIKE '%{buscar}%' OR " +
                            $"LOWER(Apellido_Paciente) LIKE '%{buscar}%' OR " +
                            $"LOWER(Fecha_De_Nacimiento) LIKE '%{buscar}%' OR " +
                            $"LOWER(Dni) LIKE '%{buscar}%' OR " +
                            $"LOWER(Email) LIKE '%{buscar}%' OR " +
                            $"LOWER(Telefono) LIKE '%{buscar}%' OR " +
                            $"LOWER(Calle) LIKE '%{buscar}%' OR " +
                            $"LOWER(Numero) LIKE '%{buscar}%' OR " +
                            $"LOWER(Piso) LIKE '%{buscar}%' OR " +
                            $"LOWER(Nombre_Localidad) LIKE '%{buscar}%' OR " +
                            $"LOWER(Codigo_Postal) LIKE '%{buscar}%' AND " +
                            $"(Baja_Pacientes IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable BuscarEnTablaPersonalLaboratorio(string buscar)
        {
            buscar = buscar.ToLower();
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = $"SELECT " +
                        $"Pk_Id_Personal_Laboratorio AS ID, " +
                        $"Nombre_Personal AS Nombre, " +
                        $"Apellido_Personal AS Apellido, " +
                        $"Dni, " +
                        $"Nombre_Categoria AS Categoria, " +
                        $"Nombre_Especialidad AS Especialidad " +
                        $"FROM PersonalLaboratorio " +
                            $"INNER JOIN Categorias ON Fk_Id_Categorias = Pk_Id_Categorias " +
                            $"INNER JOIN Especialidades ON Fk_Id_Especialidades = Pk_Id_Especialidades " +
                        $"WHERE " +
                            $"(LOWER(Nombre_Personal) LIKE '%{buscar}%' OR " +
                            $"LOWER(Apellido_Personal) LIKE '%{buscar}%' OR " +
                            $"LOWER(Dni) LIKE '%{buscar}%' OR " +
                            $"LOWER(Nombre_Categoria) LIKE '%{buscar}%' OR " +
                            $"LOWER(Nombre_Especialidad) LIKE '%{buscar}%') AND " +
                            $"(Baja_Personal IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }

        public DataTable BuscarEnTablaPacientesSoloPorDni(string buscar)
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = $"SELECT Dni FROM Pacientes WHERE Dni LIKE '{buscar}%' AND Baja_Pacientes IS NULL;";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }
        public DataTable BuscarEnTablaProfesionales(string buscar)
        {
            buscar = buscar.ToLower();
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = $"SELECT " +
                    $"Pk_Id_Profesionales AS ID, " +
                    $"Nombre_Profesional AS Nombre, " +
                    $"Apellido_Profesional AS Apellido, " +
                    $"Matricula, " +
                    $"Nombre_Servicio AS Servicio " +
                    $"FROM Profesionales " +
                        $"INNER JOIN Servicios ON Fk_Id_Servicios = Pk_Id_Servicios " +
                    $"WHERE " +
                        $"LOWER(Nombre_Profesional) LIKE '%{buscar}%' OR " +
                        $"LOWER(Apellido_Profesional) LIKE '%{buscar}%' OR " +
                        $"LOWER(Matricula) LIKE '%{buscar}%' OR " +
                        $"LOWER(Nombre_Servicio) LIKE '%{buscar}%' AND " +
                        $"(Baja_Profesional IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }
        public DataTable BuscarEnTablaEspecialidades(string buscar)
        {
            buscar = buscar.ToLower();
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = $"SELECT Pk_Id_Especialidades AS ID, " +
                                    $"Nombre_Especialidad AS Especialidad " +
                                    $"FROM Especialidades " +
                                    $"WHERE LOWER(Nombre_Especialidad) LIKE '%{buscar}%' AND " +
                                    $"(Fecha_Baja IS NULL)";
                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }
        public DataTable BuscarEnTablaPracticas(string buscar)
        {
            buscar = buscar.ToLower();
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = $"SELECT " +
                    $"p.Pk_Id_Practicas AS ID, " +
                    $"p.Nombre_Practica AS Nombre, " +
                    $"CONVERT(varchar,p.Tiempo_Demora,120) AS 'Tiempo de Demora'," +
                    $"t.Nombre_Tipo_De_Muestra AS 'Tipo De Muestra'," +
                    $"e.Nombre_Especialidad AS Especialidades " +
                    $"FROM Practicas AS p " +
                        $"INNER JOIN TiposDeMuestras AS t ON t.Pk_Id_Tipos_De_Muestra = p.Fk_Id_Tipos_De_Muestra " +
                        $"INNER JOIN Especialidades AS e ON e.Pk_Id_Especialidades = p.Fk_Id_Especialidades " +
                    $"WHERE (LOWER(p.Nombre_Practica) LIKE '%{buscar}%' OR " +
                        $"CONVERT(varchar,p.Tiempo_Demora,120) LIKE '%{buscar}%' OR " +
                        $"LOWER(t.Nombre_Tipo_De_Muestra) LIKE '%{buscar}%' OR " +
                        $"LOWER(e.Nombre_Especialidad) LIKE '%{buscar}%') AND " +
                        $"(p.Fecha_Baja IS NULL) " +
                    $"ORDER BY Nombre, p.Tiempo_Demora, 'Tipo De Muestra', Especialidades;";

                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }
        public DataTable BuscarEnTablaIngresos(string buscar)
        {
            buscar = buscar.ToLower();
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                string consulta = $"SELECT i.Pk_Id_Ingresos AS ID, " +
                        $"CONCAT(p.Nombre_Paciente,' ',p.Apellido_Paciente) AS Paciente, " +
                        $"p.Dni, " +
                        $"CONCAT(pro.Nombre_Profesional,' ',pro.Apellido_Profesional) AS Medico, " +
                        $"CONVERT(varchar,i.Fecha_Ingreso,120) AS 'Fecha De Ingreso', " +
                        $"CONVERT(varchar,i.Retirado,120) AS 'Fecha De Retiro', " +
                        $"COUNT(pxi.Fk_Id_Ingresos) AS Practicas " +
                    $"FROM Ingresos AS i " +
                        $"INNER JOIN Profesionales AS pro ON i.Fk_Id_Profesionales = pro.Pk_Id_Profesionales AND pro.Baja_Profesional IS NULL " +
                        $"INNER JOIN Pacientes AS p ON p.Pk_Id_Pacientes = i.Fk_Id_Paciente AND p.Baja_Pacientes IS NULL " +
                        $"LEFT JOIN PracticasxIngresos AS pxi ON pxi.Fk_Id_Ingresos = i.Pk_Id_Ingresos " +
                    $"WHERE " +
                        $"LOWER(p.Nombre_Paciente) LIKE '%{buscar}%' OR " +
                        $"LOWER(p.Apellido_Paciente) LIKE '%{buscar}%' OR " +
                        $"LOWER(p.Dni) LIKE '%{buscar}%' OR " +
                        $"LOWER(i.Fecha_Ingreso) LIKE '%{buscar}%' OR " +
                        $"LOWER(i.Retirado) LIKE '%{buscar}%' OR " +
                        $"LOWER(pro.Nombre_Profesional) LIKE '%{buscar}%' OR " +
                        $"LOWER(pro.Apellido_Profesional) LIKE '%{buscar}%' " +
                        $"AND (i.Retirado IS NULL) " +
                    $"GROUP BY " +
                        $"i.Pk_Id_Ingresos, CONCAT(p.Nombre_Paciente,' ',p.Apellido_Paciente), p.Dni, " +
                        $"CONCAT(pro.Nombre_Profesional,' ',pro.Apellido_Profesional), i.Fecha_Ingreso, i.Retirado " +
                    $"ORDER BY " +
                        $"Paciente, Dni, Medico, 'Fecha De Ingreso', 'Fecha De Retiro';";

                SqlDataAdapter command = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                command.Fill(tabla);
                return tabla;
            }
        }
        public void AgregarPaciente(string nombre, string apellido, string Fecha_De_Nacimiento, string Dni, string Email, string Telefono, string Calle, string Numero, string Piso, int fk_id)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO Pacientes (Nombre_Paciente, Apellido_Paciente, Fecha_De_Nacimiento, Dni, Email, Telefono, Calle, Numero, Piso, Fk_Id_Localidades) " +
                    "VALUES (@nombre_paciente,@apellido_paciente,@fecha_nacimiento,@dni,@email,@telefono,@calle,@numero,@piso,@fk_id_localidades);";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre_paciente", nombre);
                    cmd.Parameters.AddWithValue("@apellido_paciente", apellido);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", Fecha_De_Nacimiento);
                    cmd.Parameters.AddWithValue("@dni", Dni);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@telefono", Telefono);
                    cmd.Parameters.AddWithValue("@calle", Calle);
                    cmd.Parameters.AddWithValue("@numero", Numero);
                    cmd.Parameters.AddWithValue("@piso", Piso);
                    cmd.Parameters.AddWithValue("@fk_id_localidades", fk_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarProfesionales(string nombre, string apellido, int Matricula,int Fk_Id_Servicios) {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO Profesionales ( Nombre_Profesional, Apellido_Profesional, Matricula, Fk_Id_Servicios) " +
                     "VALUES (@nombre_profesional,@apellido_profesional,@matricula,@fk_id_servicios);";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre_profesional", nombre);
                    cmd.Parameters.AddWithValue("@apellido_profesional", apellido);
                    cmd.Parameters.AddWithValue("@matricula", Matricula);
                    cmd.Parameters.AddWithValue("@fk_id_servicios", Fk_Id_Servicios);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarServicios(string nombre)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO Servicios (Nombre_Servicio) VALUES (@nombre)";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int ValidarSiexisteServicio(string nombre)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "SELECT 1 FROM Servicios WHERE Nombre_Servicio = @nombre";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void AgregarEspecialidades(string nombre_especialidad)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO Especialidades (Nombre_Especialidad) VALUES (@nombre_especialidad);";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre_especialidad", nombre_especialidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarTiposDeMuestras(string nombre_muestra)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO TiposDeMuestras (Nombre_Tipo_De_Muestra) VALUES (@nombre_muestra);";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre_muestra", nombre_muestra);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarPracticas(string nombre_practica, int fk_id_especialidades, int fk_id_tiposdemuestra,int tiempo_demora)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO Practicas (Nombre_Practica, Fk_Id_Especialidades, Fk_Id_Tipos_De_Muestra, Tiempo_Demora) " +
                    "VALUES (@nombre_practica,@fk_id_especialidades,@fk_id_tiposdemuestra,@tiempo_demora);";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre_practica", nombre_practica);
                    cmd.Parameters.AddWithValue("@fk_id_especialidades", fk_id_especialidades);
                    cmd.Parameters.AddWithValue("@fk_id_tiposdemuestra", fk_id_tiposdemuestra);
                    cmd.Parameters.AddWithValue("@tiempo_demora", tiempo_demora);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarLocalidades(string Nombre_Localidad, string Codigo_Postal)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO Localidades (Nombre_Localidad, Codigo_Postal) VALUES (@nombre_localidad, @codigo_postal);";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre_localidad", Nombre_Localidad);
                    cmd.Parameters.AddWithValue("@codigo_postal", Codigo_Postal);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarCategorias(string Nombre_Categoria)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO Categorias (Nombre_Categoria) VALUES (@nombre_categoria);";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre_categoria", Nombre_Categoria);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarPersonalLaboratorio(string nombre_personal,string Dni, string apellido_personal, int fk_id_categorias, int fk_id_especialidades)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO PersonalLaboratorio (Nombre_Personal, Apellido_Personal,Dni ,Fk_Id_Categorias, Fk_Id_Especialidades) " +
                    "VALUES (@nombre_personal, @apellido_personal,@Dni ,@fk_id_categorias, @fk_id_especialidades);";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@nombre_personal", nombre_personal);
                    cmd.Parameters.AddWithValue("@apellido_personal", apellido_personal);
                    cmd.Parameters.AddWithValue("@Dni", Dni);
                    cmd.Parameters.AddWithValue("@fk_id_categorias", fk_id_categorias);
                    cmd.Parameters.AddWithValue("@fk_id_especialidades", fk_id_especialidades);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarIngresos(string fecha_ingreso, int fk_id_pacientes, int fk_id_profesionales)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO Ingresos (Fecha_Ingreso, Fk_Id_Paciente, Fk_Id_Profesionales) " +
                    $"VALUES ('{fecha_ingreso}', @fk_id_pacientes, @fk_id_profesionales);";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@fk_id_pacientes", fk_id_pacientes);
                    cmd.Parameters.AddWithValue("@fk_id_profesionales", fk_id_profesionales);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarPracticasxIngresos(int fk_id_ingresos, int fk_id_practicas)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "INSERT INTO PracticasxIngresos (Fk_Id_Ingresos, Fk_Id_Practicas) " +
                    "VALUES (@fk_id_ingresos, @fk_id_practicas);";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@fk_id_ingresos", fk_id_ingresos);
                    cmd.Parameters.AddWithValue("@fk_id_practicas", fk_id_practicas);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ModificarLocalidades(int id, string nombre_localidad, string codigo_postal)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE Localidades SET Nombre_Localidad = @nombre_localidad, Codigo_Postal = @codigo_postal WHERE Pk_Id_Localidades = @pk_id_localidad;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_localidad", id);
                    cmd.Parameters.AddWithValue("@nombre_localidad", nombre_localidad);
                    cmd.Parameters.AddWithValue("@codigo_postal", codigo_postal);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarServicios(int id, string nombre_servicio)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE Servicios SET Nombre_Servicio = @nombre_servicio WHERE Pk_Id_Servicios = @pk_id_servicio;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_servicio", id);
                    cmd.Parameters.AddWithValue("@nombre_servicio", nombre_servicio);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarCategorias(int id, string nombre_categoria)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE Categorias SET Nombre_Categoria = @nombre_categoria WHERE Pk_Id_Categorias = @pk_id_categoria;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_categoria", id);
                    cmd.Parameters.AddWithValue("@nombre_categoria", nombre_categoria);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarTiposDeMuestras(int id, string nombre_muestra)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE TiposDeMuestras SET Nombre_Tipo_De_Muestra = @nombre_muestra WHERE Pk_Id_Tipos_De_Muestra = @pk_id_tipodemuestra;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_tipodemuestra", id);
                    cmd.Parameters.AddWithValue("@nombre_muestra", nombre_muestra);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarEspecialidades(int id, string nombre_especialidad)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE Especialidades SET Nombre_Especialidad = @nombre_especialidad WHERE Pk_Id_Especialidades = @pk_id_especialidad;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_especialidad", id);
                    cmd.Parameters.AddWithValue("@nombre_especialidad", nombre_especialidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarPacientes(int id, string nombre, string apellido, string Fecha_De_Nacimiento, string Dni, string Email, string Telefono, string Calle, string Numero, string Piso, int fk_id)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE Pacientes SET Nombre_Paciente = @nombre_paciente, Apellido_Paciente = @apellido_paciente, Fecha_De_Nacimiento = @fecha_nacimiento, " +
                    "Dni = @dni, Email = @email, Telefono = @telefono, Calle = @calle, Numero = @numero, Piso = @piso, Fk_Id_Localidades = @fk_id_localidad " +
                    "WHERE Pk_Id_Pacientes = @pk_id_paciente;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_paciente", id);
                    cmd.Parameters.AddWithValue("@nombre_paciente", nombre);
                    cmd.Parameters.AddWithValue("@apellido_paciente", apellido);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", Fecha_De_Nacimiento);
                    cmd.Parameters.AddWithValue("@dni", Dni);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@telefono", Telefono);
                    cmd.Parameters.AddWithValue("@calle", Calle);
                    cmd.Parameters.AddWithValue("@numero", Numero);
                    cmd.Parameters.AddWithValue("@piso", Piso);
                    cmd.Parameters.AddWithValue("@fk_id_localidad", fk_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarProfesionales(int id, string nombre, string apellido, int Matricula, int Fk_Id_Servicios)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE Profesionales SET Nombre_Profesional = @nombre_profesional, Apellido_Profesional = @apellido_profesional, Matricula = @matricula, " +
                    "Fk_Id_Servicios = @fk_id_servicio WHERE Pk_Id_Profesionales = @pk_id_profesional;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_profesional", id);
                    cmd.Parameters.AddWithValue("@nombre_profesional", nombre);
                    cmd.Parameters.AddWithValue("@apellido_profesional", apellido);
                    cmd.Parameters.AddWithValue("@matricula", Matricula);
                    cmd.Parameters.AddWithValue("@fk_id_servicio", Fk_Id_Servicios);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarPersonalLaboratorio(int id, string nombre, string apellido, int fk_id_categoria, int fk_id_especialidad)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE PersonalLaboratorio SET Nombre_Personal = @nombre_personal, Apellido_Personal = @apellido_personal, Fk_Id_Categorias = @fk_id_categoria, " +
                    "Fk_Id_Especialidades = @fk_id_especialidad WHERE Pk_Id_Personal_Laboratorio = @pk_id_personal_laboratorio;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_personal_laboratorio", id);
                    cmd.Parameters.AddWithValue("@nombre_personal", nombre);
                    cmd.Parameters.AddWithValue("@Apellido_Personal", apellido);
                    cmd.Parameters.AddWithValue("@fk_id_categoria", fk_id_categoria);
                    cmd.Parameters.AddWithValue("@fk_id_especialidad", fk_id_especialidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarIngresos(int id, string fecha_ingreso, string retirado, int fk_id_paciente, int fk_id_profesional)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE Ingresos SET Fecha_Ingreso = @fecha_ingreso, Retirado = @retirado, Fk_Id_Paciente = @fk_id_paciente, " +
                    "Fk_Id_Profesionales = @fk_id_profesional WHERE Pk_Id_Ingresos = @pk_id_ingreso;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_ingreso", id);
                    cmd.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso);
                    cmd.Parameters.AddWithValue("@retirado", retirado);
                    cmd.Parameters.AddWithValue("@fk_id_paciente", fk_id_paciente);
                    cmd.Parameters.AddWithValue("@fk_id_profesional", fk_id_profesional);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarPracticas(int id, int tiempo_demora, string nombre_practica, int fk_id_especialidad, int fk_id_tipodemuestra)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE Practicas SET Tiempo_Demora = @tiempo_demora, Nombre_Practica = @nombre_practica, " +
                    "Fk_Id_Especialidades = @fk_id_especialidad, Fk_Id_Tipos_De_Muestra = @fk_id_tipodemuestra " +
                    "WHERE Pk_Id_Practicas = @pk_id_practica;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_practica", id);
                    cmd.Parameters.AddWithValue("@tiempo_demora", tiempo_demora);
                    cmd.Parameters.AddWithValue("@nombre_practica", nombre_practica);
                    cmd.Parameters.AddWithValue("@fk_id_especialidad", fk_id_especialidad);
                    cmd.Parameters.AddWithValue("@fk_id_tipodemuestra", fk_id_tipodemuestra);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarPracticasxIngresos(int id, int fk_id_ingreso, int fk_id_practica)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "UPDATE PracticasxIngresos SET Fk_Id_Ingresos = @fk_id_ingreso, Fk_Id_Practicas = @fk_id_practica WHERE Pk_Id_PracticasxIngresos = @pk_id_practicaxingreso;";

                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@pk_id_practicaxingreso", id);
                    cmd.Parameters.AddWithValue("@fk_id_ingreso", fk_id_ingreso);
                    cmd.Parameters.AddWithValue("@fk_id_practica", fk_id_practica);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarIngresos(int id)
        {
            using(SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"UPDATE Ingresos SET Retirado = '{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}'  WHERE Pk_Id_Ingresos = {id}";
                using(SqlCommand cmd = new SqlCommand(consulta,conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarPracticaXIngreso(int id)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"DELETE FROM PracticasxIngresos WHERE Pk_Id_PracticasxIngresos = {id}";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarLocalidades(int id) 
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"UPDATE Localidades SET Fecha_Baja = '{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}'  WHERE Pk_Id_Localidades = {id}";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarServicios(int id)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"UPDATE Servicios SET Fecha_Baja = '{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}'  WHERE Pk_Id_Servicios = {id}";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarCategorias(int id)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"UPDATE Categorias SET Fecha_Baja = '{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}'  WHERE Pk_Id_Categorias = {id}";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarTiposDeMuestra(int id)
        {
            using(SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"UPDATE TiposDeMuestras SET Fecha_Baja = '{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}' WHERE Pk_Id_Tipos_De_Muestra = {id}";
                using(SqlCommand cmd = new SqlCommand(consulta,conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarEspecialidad(int id)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"UPDATE Especialidades SET Fecha_Baja = '{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}' WHERE Pk_Id_Especialidades = {id}";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarPacientes(int id)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"UPDATE Pacientes SET Baja_Pacientes = '{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}' WHERE Pk_Id_Pacientes= {id}";
                using (SqlCommand cmd = new SqlCommand(consulta,conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
         
        public void EliminarProfesional(int id)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"UPDATE Profesionales SET Baja_Profesional = '{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}' WHERE Pk_Id_Profesionales = {id}";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarPersonalLaboratorio(int id)
          {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"UPDATE PersonalLaboratorio SET Baja_Personal = '{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}' WHERE Pk_Id_Personal_Laboratorio = {id}";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarPracticas(int id)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = $"UPDATE Practicas SET Fecha_Baja = '{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}'  WHERE Pk_Id_Practicas = {id}";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public int ObtenerId_Localidades(string localidad)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "SELECT Pk_Id_Localidades FROM Localidades WHERE Nombre_Localidad = @localidad";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@localidad", localidad);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public int ObtenerId_Servicios(string servicio)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "SELECT Pk_Id_Servicios FROM Servicios WHERE Nombre_Servicio = @servicio";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@servicio", servicio);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public int ObtenerId_Medicos(string matricula)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "SELECT Pk_Id_Profesionales FROM Profesionales WHERE Matricula = @matricula";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@matricula", matricula);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public int ObtenerId_Categorias(string categoria)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "SELECT Pk_Id_Categorias FROM Categorias WHERE Nombre_Categoria = @categoria";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public int ObtenerId_TiposDeMuestras(string muestra)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "SELECT Pk_Id_Tipos_De_Muestra FROM TiposDeMuestras WHERE Nombre_Tipo_De_Muestra = @muestra";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@muestra", muestra);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public int ObtenerId_Especialidades(string especialidad)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "SELECT Pk_Id_Especialidades FROM Especialidades WHERE Nombre_Especialidad = @especialidad";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@especialidad", especialidad);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int ObtenerId_Pacientes(string dni)
        {
            using (SqlConnection conectar = new SqlConnection(contrasenia))
            {
                conectar.Open();
                string consulta = "SELECT Pk_Id_Pacientes FROM Pacientes WHERE Dni = @dni";
                using (SqlCommand cmd = new SqlCommand(consulta, conectar))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    if (cmd.ExecuteScalar() != null) 
                    { 
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
        public int ObtenerId_Profesionales(string personal)
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                conexion.Open();
                string consulta = "SELECT Pk_Id_Profesionales AS ID FROM Profesionales " +
                        "WHERE CONCAT(Apellido_Profesional,' ', Nombre_Profesional) = @Personal";
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@Personal", personal);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int BuscarTiempoDemora(int id)
        {
            using (SqlConnection conexion = new SqlConnection (contrasenia)) 
            {
                conexion.Open();
                string consulta = "SELECT MAX(p.Tiempo_Demora) AS 'Demora en hs'" +
                                    "FROM Practicas AS p INNER JOIN PracticasxIngresos AS PxI " +
                                    "ON p.Pk_Id_Practicas = PxI.Fk_Id_Practicas " +
                                    "INNER JOIN Ingresos AS I " +
                                    "ON PxI.Fk_Id_Ingresos = I.Pk_Id_Ingresos " +
                                    $"WHERE I.Pk_Id_Ingresos = {id}";
                using (SqlCommand cmd = new SqlCommand (consulta, conexion)) 
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public int BuscarPractica(string practica)
        {
            using (SqlConnection conexion = new SqlConnection(contrasenia))
            {
                conexion.Open();
                string consulta = "SELECT Pk_Id_Practicas " +
                                    "FROM Practicas " +
                                    $"WHERE Nombre_Practica = @practica";
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@practica", practica);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void ActualizarFecha_Retiro(int id,string retirado)
        {
            using(SqlConnection conexion = new SqlConnection(contrasenia))
            {
                conexion.Open();
                string consulta = $"UPDATE Ingresos SET Retirado = @retirado " +
                                    $"WHERE Pk_Id_Ingresos = {id}";
                using (SqlCommand cmd = new SqlCommand (consulta,conexion)) 
                {
                    cmd.Parameters.AddWithValue("@retirado", retirado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int ObtenerUltimaIDIngresos()
        {
            int ultimaID = 0;

            using (SqlConnection connection = new SqlConnection(contrasenia))
            {
                connection.Open();

                // Ejecuta la consulta SQL para obtener la última ID de la tabla Ingresos
                string query = "SELECT MAX(Pk_Id_Ingresos) AS UltimaID FROM Ingresos";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            // Obtiene el valor de la última ID
                            ultimaID = Convert.ToInt32(reader["UltimaID"]);
                        }
                    }
                }
            }

            return ultimaID;
        }

    }
}
