using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LCSA.SGI.WebLogisticaUtiles.Entity.casaCambioWs;

namespace LCSA.SGI.WebLogisticaUtiles.Entity
{
    public class EReqCabecera
    {
        private CasaCambioWs casaCambioWS;
        private string situacion;
        public string Situacion
        {
            get { return situacion; }
            set { situacion = value; }
        }

        private string nroRequerimiento;
        public string NroRequerimiento
        {
            get { return nroRequerimiento; }
            set { nroRequerimiento = value; }
        }

        private decimal tipoSalida;
        public decimal TipoSalida
        {
            get { return tipoSalida; }
            set { tipoSalida = value; }
        }

        private decimal fechaSalida;
        public decimal FechaSalida
        {
            get { return fechaSalida; }
            set { fechaSalida = value; }
        }

        private decimal turno;
        public decimal Turno
        {
            get { return turno; }
            set { turno = value; }
        }

        private decimal area;
        public decimal Area
        {
            get { return area; }
            set { area = value; }
        }

        private decimal autorizado;
        public decimal Autorizado
        {
            get { return autorizado; }
            set { autorizado = value; }
        }

        private decimal solicitante;
        public decimal Solicitante
        {
            get { return solicitante; }
            set { solicitante = value; }
        }

        private decimal ordenTrabajo;
        public decimal OrdenTrabajo
        {
            get { return ordenTrabajo; }
            set { ordenTrabajo = value; }
        }

        private decimal recibido;
        public decimal Recibido
        {
            get { return recibido; }
            set { recibido = value; }
        }

        private string tipoAlmacen;
        public string TipoAlmacen
        {
            get { return tipoAlmacen; }
            set { tipoAlmacen = value; }
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


        private decimal codUserGenera;
        public decimal CodUserGenera
        {
            get { return codUserGenera; }
            set { codUserGenera = value; }
        }

        private string userGenera;
        public string UserGenera
        {
            get { return userGenera; }
            set { userGenera = value; }
        }

        private decimal codUserAprueba1;
        public decimal CodUserAprueba1
        {
            get { return codUserAprueba1; }
            set { codUserAprueba1 = value; }
        }

        private string userAprueba1;
        public string UserAprueba1
        {
            get { return userAprueba1; }
            set { userAprueba1 = value; }
        }


        private decimal codUserAprueba2;
        public decimal CodUserAprueba2
        {
            get { return codUserAprueba2; }
            set { codUserAprueba2 = value; }
        }

        private string userAprueba2;
        public string UserAprueba2
        {
            get { return userAprueba2; }
            set { userAprueba2 = value; }
        }

        private decimal codUserAprueba3;
        public decimal CodUserAprueba3
        {
            get { return codUserAprueba3; }
            set { codUserAprueba3 = value; }
        }

        private string userAprueba3;
        public string UserAprueba3
        {
            get { return userAprueba3; }
            set { userAprueba3 = value; }
        }

        private string fechaGenera;
        public string FechaGenera
        {
            get { return fechaGenera; }
            set { fechaGenera = value; }
        }

        private string fechaAprueba1;
        public string FechaAprueba1
        {
            get { return fechaAprueba1; }
            set { fechaAprueba1 = value; }
        }

        private string fechaAprueba2;
        public string FechaAprueba2
        {
            get { return fechaAprueba2; }
            set { fechaAprueba2 = value; }
        }

        private string fechaAprueba3;
        public string FechaAprueba3
        {
            get { return fechaAprueba3; }
            set { fechaAprueba3 = value; }
        }

        private decimal horaMinuto;
        public decimal HoraMinuto
        {
            get { return horaMinuto; }
            set { horaMinuto = value; }
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

        private decimal fechaValeSalida;
        public decimal FechaValeSalida
        {
            get { return fechaValeSalida; }
            set { fechaValeSalida = value; }
        }

        private decimal horaValeSalida;
        public decimal HoraValeSalida
        {
            get { return horaValeSalida; }
            set { horaValeSalida = value; }
        }

        private string usuarioDespacha;
        public string UsuarioDespacha
        {
            get { return usuarioDespacha; }
            set { usuarioDespacha = value; }
        }

        public void usarWWs(double monto)
        {


            cambiarDolaresaSolesRequest request = new cambiarDolaresaSolesRequest();

            request.monto = monto;

            cambiarDolaresaSolesResponse response = new cambiarDolaresaSolesResponse();

            response = casaCambioWS.cambiarDolaresaSoles(request);

            
        }
    }
}
