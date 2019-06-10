const mongoose = require('mongoose');

const BillSchema = mongoose.Schema({
    _id:mongoose.SchemaTypes.ObjectId,
    tableID: mongoose.SchemaTypes.ObjectId,
    employeeID: mongoose.SchemaTypes.ObjectId,
    tableNumber: Number,
    billNumber: Number,   
    status: String,
    promotion: Number,
    total: Number,
    customer: {
        fullName : String,
        phone:  String
    },
    menu: Array,
    time : String
}, {
    timestamps: true
});

module.exports = mongoose.model('Bill', BillSchema);