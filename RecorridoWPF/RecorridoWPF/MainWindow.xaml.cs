using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecorridoWPF
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    Datos.DataBaseRecorridoAutoEntities miBd = new Datos.DataBaseRecorridoAutoEntities();

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      int cantidad = miBd.RecorridoHyundai30.Count();
      txtRegistros.Text = cantidad.ToString();
      MessageBox.Show(cantidad.ToString());
    }

    private void btnMostra_Click(object sender, RoutedEventArgs e)
    {
      int numeroABuscar = int.Parse(txtBuscarId.Text);

      //obtengo de bd
      var fila = miBd.RecorridoHyundai30.Where(y => y.IdRecorrido == numeroABuscar).SingleOrDefault();

      if (fila == null)
      {
        Limpiar();
        MessageBox.Show("valor no encontrado");
      }
      else
      {
        txtLugarSalida.Text = fila.LugarSalida;
        txtFechaSalida.Text = fila.FechaSalida.ToString("yyyy-MM-dd");
        txtHoraSalida.Text = fila.HoraSalida.ToString();
        txtTanqueSalida.Text = fila.TanqueSalida_Km_.ToString();
        txtKilometrajeSalida.Text = fila.KilometrajeSalida_Km_.ToString();

        txtLugarLlegada.Text = fila.LugarLlegada;
        txtFechaLlegada.Text = fila.FechaLlegada.ToString("yyyy-MM-dd");
        txtHoraLlegada.Text = fila.HoraLlegada.ToString();
        txtTanqueLlegada.Text = fila.TanqueLlegada_Km_.ToString();
        txtKilometrajeLlegada.Text = fila.KilometrajeLlegada_Km_.ToString();
      }
      int cantidad = miBd.RecorridoHyundai30.Count();
      txtRegistros.Text = cantidad.ToString();
    }

    private void buttonLimpiar_Click(object sender, RoutedEventArgs e) 
    {
      txtBuscarId.Text = "";

      txtLugarSalida.Text = "";
      txtFechaSalida.Text = "";
      txtHoraSalida.Text = "";
      txtTanqueSalida.Text = "";
      txtKilometrajeSalida.Text = "";

      txtLugarLlegada.Text = "";
      txtFechaLlegada.Text = "";
      txtHoraLlegada.Text = "";
      txtTanqueLlegada.Text = "";
      txtKilometrajeLlegada.Text = "";
    }

    private void btnActualizar_Click(object sender, RoutedEventArgs e)
    {
      int numeroABuscar = int.Parse(txtBuscarId.Text);

      //  var fila = miBd.RecorridoHyundai30.Where(x => x.IdRecorrido == numeroABuscar).Single();
      var filaSql = from x in miBd.RecorridoHyundai30
                    where x.IdRecorrido == numeroABuscar
                    select x;

      var fila = filaSql.Single();

      fila.LugarSalida = txtLugarSalida.Text;
      fila.FechaSalida = DateTime.Parse(txtFechaSalida.Text);
      fila.HoraSalida = TimeSpan.Parse(txtHoraSalida.Text);
      fila.TanqueSalida_Km_ = int.Parse(txtTanqueSalida.Text);
      fila.KilometrajeSalida_Km_ = int.Parse(txtKilometrajeSalida.Text);

      fila.LugarLlegada = txtLugarLlegada.Text;
      fila.FechaLlegada = DateTime.Parse(txtFechaLlegada.Text);
      fila.HoraLlegada = TimeSpan.Parse(txtHoraLlegada.Text);
      fila.TanqueLlegada_Km_ = int.Parse(txtTanqueLlegada.Text);
      fila.KilometrajeLlegada_Km_ = int.Parse(txtKilometrajeLlegada.Text);

      int cantidad = miBd.RecorridoHyundai30.Count();
      txtRegistros.Text = cantidad.ToString();

      miBd.SaveChanges();
      MessageBox.Show("Acualizado");
    }

    private void btnAgregar_Click(object sender, RoutedEventArgs e)
    {
      Datos.RecorridoHyundai30 miNuevoRegistro = new Datos.RecorridoHyundai30();

      int ultimoNumero = miBd.RecorridoHyundai30.Max(x => x.IdRecorrido);
      int nuevoId = ultimoNumero + 1;

      miNuevoRegistro.IdRecorrido = nuevoId;

      miNuevoRegistro.LugarSalida = txtLugarSalida.Text;
      miNuevoRegistro.FechaSalida = DateTime.Parse(txtFechaSalida.Text);
      miNuevoRegistro.HoraSalida = TimeSpan.Parse(txtHoraSalida.Text);
      miNuevoRegistro.TanqueSalida_Km_ = int.Parse(txtTanqueSalida.Text);
      miNuevoRegistro.KilometrajeSalida_Km_ = int.Parse(txtKilometrajeSalida.Text);

      miNuevoRegistro.LugarLlegada = txtLugarLlegada.Text;
      miNuevoRegistro.FechaLlegada = DateTime.Parse(txtFechaLlegada.Text);
      miNuevoRegistro.HoraLlegada = TimeSpan.Parse(txtHoraLlegada.Text);
      miNuevoRegistro.TanqueLlegada_Km_ = int.Parse(txtTanqueLlegada.Text);
      miNuevoRegistro.KilometrajeLlegada_Km_ = int.Parse(txtKilometrajeLlegada.Text);

      miBd.RecorridoHyundai30.Add(miNuevoRegistro);
      miBd.SaveChanges();

      int cantidad = miBd.RecorridoHyundai30.Count();
      txtRegistros.Text = cantidad.ToString();
      MessageBox.Show("Agregado");
    }

    private void btnEliminar_Click(object sender, RoutedEventArgs e)
    {
      int numeroABuscar = int.Parse(txtBuscarId.Text);

      var fila = miBd.RecorridoHyundai30.Where(x => x.IdRecorrido == numeroABuscar).Single();
      
      miBd.RecorridoHyundai30.Remove(fila);
      miBd.SaveChanges();

      Limpiar();

      int cantidad = miBd.RecorridoHyundai30.Count();
      txtRegistros.Text = cantidad.ToString();
      MessageBox.Show("Eliminado");
    }

    private void Limpiar()
    {
      txtBuscarId.Text = "";

      txtLugarSalida.Text = "";
      txtFechaSalida.Text = "";
      txtHoraSalida.Text = "";
      txtTanqueSalida.Text = "";
      txtKilometrajeSalida.Text = "";

      txtLugarLlegada.Text = "";
      txtFechaLlegada.Text = "";
      txtHoraLlegada.Text = "";
      txtTanqueLlegada.Text = "";
      txtKilometrajeLlegada.Text = "";
    }
  }
}
