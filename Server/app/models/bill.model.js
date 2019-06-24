const mongoose = require('mongoose');

const BillSchema = mongoose.Schema({
    employeeName: String,
    tableNumber: Number,
    billNumber: Number,   
    status: String,
    promotion: String,
    total: Number,
    customer: {
        fullName : String,
        phone:  String
    },
    menu: Array
}, {
    timestamps: true
});

module.exports = mongoose.model('Bill', BillSchema);