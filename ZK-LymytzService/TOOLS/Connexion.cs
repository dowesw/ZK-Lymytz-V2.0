﻿using System;
using System.Collections.Generic;
using System.Text;

using Npgsql;
using ZK_LymytzService.BLL;

namespace ZK_LymytzService.TOOLS
{
    public class Connexion
    {
        public NpgsqlConnection Connection()
        {
            NpgsqlConnection con = new NpgsqlConnection();
            ENTITE.Serveur bean = ServeurBLL.ReturnServeur();
            if ((bean != null) ? bean.Port != 0 : false)
            {
                con = getConnexion(bean);
            }
            return con;
        }

        public NpgsqlConnection Connection1()
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection();
                string constr = "PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;COMPATIBLE= 2.0.14.3;DATABASE=lymytz;HOST=192.168.1.251;PASSWORD=yves1910/;USER ID=postgres";
                con = new NpgsqlConnection(constr);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public NpgsqlConnection getConnexion(ENTITE.Serveur bean)
        {
            try
            {
                NpgsqlConnection con = new NpgsqlConnection();
                if (isConnection(out con, bean))
                {
                    return con;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool isConnection(out NpgsqlConnection con, ENTITE.Serveur bean)
        {
            con = null;
            try
            {
                if (bean != null)
                {
                    string constr = "PORT=" + bean.Port + ";TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;COMPATIBLE= 2.0.14.3;DATABASE=" + bean.Database + ";HOST=" + bean.Adresse + ";PASSWORD=" + bean.Password + ";USER ID=" + bean.User + "";
                    con = new NpgsqlConnection(constr);
                    con.Open();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool isInfosServeur(ENTITE.Serveur bean)
        {
            try
            {
                if (bean != null)
                {
                    string constr = "PORT=" + bean.Port + ";TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;COMPATIBLE= 2.0.14.3;DATABASE=" + bean.Database + ";HOST=" + bean.Adresse + ";PASSWORD=" + bean.Password + ";USER ID=" + bean.User + "";
                    NpgsqlConnection con = new NpgsqlConnection(constr);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}