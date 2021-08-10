Ext.define('HotelSys.view.reservation.ReservationViewModel', {
  extend: 'Ext.app.ViewModel',
  alias: 'viewmodel.reservationviewmodel',
})

Ext.define('Reservation', {
  extend: 'Ext.data.Model',
  fields: [
    'reservationCode', 
    {name: 'created', type: 'date'}, 
    'price',
    {name: 'checkIn', type: 'date'}, 
    {name: 'checkOut', type: 'date'}, 
    'currency'],
  sorters: ['reservationCode', 'created', 'price', 'checkIn', 'checkOut', 'currency'],
  cls: 'store'
});

var hotel = Ext.create('Ext.data.Store', {
  model: 'Reservation',
  autoLoad: true,
  proxy: {
      type: 'rest',
      url : 'https://localhost:5001/hotel/AllReservations',
      reader: {
        type: 'json',
        rootProperty: 'reservations',
    }
  },
});



Ext.create('Ext.grid.Grid', {
  title: 'Reservations List',

  store: hotel,
 
  columns: [{
      text: 'Reservation code',
      dataIndex: 'reservationCode',
      flex: 1
  },{
      text: 'Created at',
      dataIndex: 'created',
      xtype:'datecolumn',
      format:'Y-m-d H:i:s',
      flex: 1
  },{
      text: 'Start',
      dataIndex: 'checkIn',
      xtype:'datecolumn',
      format:'Y-m-d',
      flex: 1
  },{
      text: 'End',
      dataIndex: 'checkOut',
      xtype:'datecolumn',
      format:'Y-m-d',
      flex: 1
  },{
      text: 'Price',
      dataIndex: 'price'
  },{
      text: 'Currency',
      dataIndex: 'currency'
  }],

  height: '100%',
  renderTo: Ext.getBody(),
});