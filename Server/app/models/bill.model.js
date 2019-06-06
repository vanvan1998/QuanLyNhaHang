const mongoose = require('mongoose');

const BillSchema = mongoose.Schema({
    tableID: mongoose.SchemaTypes.ObjectId,
    employeeID: mongoose.SchemaTypes.ObjectId,
    customerID: mongoose.SchemaTypes.ObjectId,
    billNumber: Number,   
    status: String,
    promotion: String,
    total: Number,
    menu: Array,
    time : Date
}, {
    timestamps: true
});

module.exports = mongoose.model('Bill', BillSchema);