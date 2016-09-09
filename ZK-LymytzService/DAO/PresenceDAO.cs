﻿using System;
using System.Collections.Generic;
using System.Text;

using NpgsqlTypes;
using Npgsql;

using ZK_LymytzService.TOOLS;
using ZK_LymytzService.ENTITE;

namespace ZK_LymytzService.DAO
{
    public class PresenceDAO
    {
        public static Presence _getOneById(int id)
        {
            Presence bean = new Presence();
            NpgsqlConnection connect = new Connexion().Connection();
            try
            {
                string query = "select * from yvs_grh_presence where id =" + id + ";";
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, connect);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        bean.Id = Convert.ToInt32(lect["id"].ToString());
                        bean.DateDebut = Convert.ToDateTime(lect["date_debut"].ToString());
                        bean.DateFin = Convert.ToDateTime(lect["date_fin"].ToString());
                        bean.HeureDebut = Convert.ToDateTime(lect["heure_debut"].ToString());
                        bean.HeureFin = Convert.ToDateTime(lect["heure_fin"].ToString());
                        bean.Employe = EmployeDAO._getOneById(Convert.ToInt32(lect["employe"].ToString()));
                        bean.Valider = Convert.ToBoolean((lect["valider"].ToString() != "") ? lect["valider"].ToString() : "false");
                    }
                }
                return bean;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public static Presence _getOneByDate(Employe empl, DateTime date)
        {
            Presence bean = new Presence();
            NpgsqlConnection connect = new Connexion().Connection();
            try
            {
                string query = "select * from yvs_grh_presence where employe =" + empl.Id + " and '" + date + "' between date_debut and date_fin order by date_debut";
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, connect);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        bean.Id = Convert.ToInt32(lect["id"].ToString());
                        bean.DateDebut = Convert.ToDateTime(lect["date_debut"].ToString());
                        bean.DateFin = Convert.ToDateTime(lect["date_fin"].ToString());
                        bean.HeureDebut = Convert.ToDateTime(lect["heure_debut"].ToString());
                        bean.HeureFin = Convert.ToDateTime(lect["heure_fin"].ToString());
                        bean.DureePause = Convert.ToDateTime(lect["duree_pause"].ToString());
                        bean.Employe = EmployeDAO._getOneById(Convert.ToInt32(lect["employe"].ToString()));
                        bean.Valider = Convert.ToBoolean((lect["valider"].ToString() != "") ? lect["valider"].ToString() : "false");
                    }
                }
                return bean;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public static Presence _getOneByDates(Employe empl, DateTime dateDebut, DateTime dateFin)
        {
            Presence bean = new Presence();
            NpgsqlConnection connect = new Connexion().Connection();
            try
            {
                string query = "select * from yvs_grh_presence where employe =" + empl.Id + " and date_debut = '" + dateDebut.ToString("yyyy-MM-dd") + "' and date_fin = '" + dateFin.ToString("yyyy-MM-dd") + "' order by date_debut";
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, connect);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        bean.Id = Convert.ToInt32(lect["id"].ToString());
                        bean.DateDebut = Convert.ToDateTime(lect["date_debut"].ToString());
                        bean.DateFin = Convert.ToDateTime(lect["date_fin"].ToString());
                        bean.HeureDebut = Convert.ToDateTime(lect["heure_debut"].ToString());
                        bean.HeureFin = Convert.ToDateTime(lect["heure_fin"].ToString());
                        bean.DureePause = Convert.ToDateTime(lect["duree_pause"].ToString());
                        bean.Employe = EmployeDAO._getOneById(Convert.ToInt32(lect["employe"].ToString()));
                        bean.Valider = Convert.ToBoolean((lect["valider"].ToString() != "") ? lect["valider"].ToString() : "false");
                    }
                }
                return bean;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public static List<Presence> _getList(string query)
        {
            List<Presence> list = new List<Presence>();
            NpgsqlConnection connect = new Connexion().Connection();
            try
            {
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, connect);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        int id = Convert.ToInt32(lect["id"].ToString());
                        list.Add(_getOneById(id));
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public static bool _getInsert(Presence bean)
        {
            NpgsqlConnection connect = new Connexion().Connection();
            try
            {
                string query = "insert into yvs_grh_presence(date_debut, heure_debut, date_fin, heure_fin, employe, valider, duree_pause, marge_approuve) values ('" + bean.DateDebut + "','" + bean.HeureDebut.ToString("HH:mm:ss") + "','" + bean.DateFin + "','" + bean.HeureFin.ToString("HH:mm:ss") + "'," + bean.Employe.Id + ",false,'" + bean.DureePause.ToString("HH:mm:ss") + "', null)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public static bool _getUpdate(Presence bean)
        {
            NpgsqlConnection connect = new Connexion().Connection();
            try
            {
                string query = "update yvs_grh_presence set marge_approuve = '" + bean.MargeApprouve.ToString("HH:mm:ss") + "' where id = " + bean.Id;
                NpgsqlCommand cmd = new NpgsqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public static Presence _setInsert(Presence bean)
        {
            try
            {
                if (_getInsert(bean))
                {
                    Presence new_ = _getList("select * from yvs_grh_presence order by id desc limit 1")[0];
                    return new_;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}