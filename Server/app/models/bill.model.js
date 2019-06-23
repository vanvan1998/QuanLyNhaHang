const mongoose = require('mongoose');

const BillSchema = mongoose.Schema({
    employeeID: mongoose.SchemaTypes.ObjectId,
    tableNumber: Number,
    billNumber: Number,   
    status: String,
    promotion: String,
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