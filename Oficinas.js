Ext.namespace('Maer.paneles.general');

Maer.paneles.general.Oficinas = Ext.extend(Maer.ux.browser.Panel, {
    cargarDirectFn: Oficinas.Get,
    guardarDirectFn: Oficinas.Guardar,
    layout: 'form',
    maximized: false,
    fondoGris: true,

    getExtraDataCallbackMsg: function (o) { return 'Oficinas ' + o; },

    initComponent: function () {

        var panel = this;
        
        this.txtDescripcion = new Ext.form.TextField({
            fieldLabel: 'Descripción',
            allowBlank: false
        });

        this.txtCodigo = new Ext.form.TextField({
            fieldLabel: 'Codigo',
            allowBlank: false
        });

        this.txtCantidadEmpleados = new Ext.form.TextField({
            fieldLabel: 'Cantidad de Empleados',
            allowBlank: false
        });

        this.txtObservacion = new Ext.form.TextField({
            fieldLabel: 'Observacion',
            allowBlank: false
        });


        var config = {
            items: [panelSuperior, this.grid],
            width: 500,
            height: 400,

            // MANEJO DE TECLADO POR PANEL
            keys: [{
                key: Ext.EventObject.F2,
                fn: this.guardar,
                scope: this,
                stopEvent: true
            }, {
                key: Ext.EventObject.DELETE,
                ctrl: true,
                fn: this.grid.deleteRow,
                scope: this.grid,
                stopEvent: true
            }, {
                key: Ext.EventObject.INSERT,
                ctrl: true,
                fn: this.grid.addRow,
                scope: this.grid,
                stopEvent: true
            }]

        };

        Ext.apply(this, Ext.apply(this.initialConfig, config));
        Maer.paneles.general.Oficinas.superclass.initComponent.apply(this, arguments);
    },
   
    init: function () {
        this.refrescarComponentesPorEmpresa();
    },
    
    refrescarComponentesPorEmpresa: function () {
        this.txtCotizacion.refreshEmpresas();
    },

});