using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCSA.SGI.WebLogisticaUtiles.Entity
{
    public class EReqDetalle
    {
        private string situacion;
        public string Situacion
        {
            get { return situacion; }
            set { situacion = value; }
        }

        private string nroReqSalida;
        public string NroReqSalida
        {
            get { return nroReqSalida; }
            set { nroReqSalida = value; }
        }

        private decimal nroItem;
        public decimal NroItem
        {
            get { return nroItem; }
            set { nroItem = value; }
        }

        private string codMatPrima;
        public string CodMatPrima
        {
            get { return codMatPrima; }
            set { codMatPrima = value; }
        }

        private decimal ctaCargo;
        public decimal CtaCargo
        {
            get { return ctaCargo; }
            set { ctaCargo = value; }
        }

        private decimal procedencia;
        public decimal Procedencia
        {
            get { return procedencia; }
            set { procedencia = value; }
        }

        private decimal ctaAlmacen;
        public decimal CtaAlmacen
        {
            get { return ctaAlmacen; }
            set { ctaAlmacen = value; }
        }

        private decimal cantidadSoli;
        public decimal CantidadSoli
        {
            get { return cantidadSoli; }
            set { cantidadSoli = value; }
        }

        private decimal cantidadAte;
        public decimal CantidadAte
        {
            get { return cantidadAte; }
            set { cantidadAte = value; }
        }

        private decimal impSoles;
        public decimal ImpSoles
        {
            get { return impSoles; }
            set { impSoles = value; }
        }

        private decimal impDolares;
        public decimal ImpDolares
        {
            get { return impDolares; }
            set { impDolares = value; }
        }

        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private decimal nroValeSalida;
        public decimal NroValeSalida
        {
            get { return nroValeSalida; }
            set { nroValeSalida = value; }
        }

        private decimal fechaSalida;
        public decimal FechaSalida
        {
            get { return fechaSalida; }
            set { fechaSalida = value; }
        }

        private decimal horaSalida;
        public decimal HoraSalida
        {
            get { return horaSalida; }
            set { horaSalida = value; }
        }

        private string userDespacha;
        public string UserDespacha
        {
            get { return userDespacha; }
            set { userDespacha = value; }
        }
    }
}
