Ext.define('HotelSys.Application', {
  extend: 'Ext.app.Application',
  name: 'HotelSys',
  requires: ['HotelSys.*'],


  removeSplash: function () {
		var elem = document.getElementById("splash")
		elem.parentNode.removeChild(elem)
	},

  launch: function () {
    this.removeSplash()
    Ext.Viewport.add([{xtype: 'reservationview'}])
  },

  onAppUpdate: function () {
    Ext.Msg.confirm('Application Update', 'This application has an update, reload?',
      function (choice) {
        if (choice === 'yes') {
          window.location.reload()
        }
      }
    )
  }
})
