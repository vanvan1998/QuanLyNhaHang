const mongoose = require('mongoose');

const TableSchema = mongoose.Schema({
    number: Number,
    note: String,
    status: String,
    numberOfSeat: Number,
    type: String,
    customer: {
        fullName : String,
        phone:  String
    }
}, {
    timestamps: true
});

module.exports = mongoose.model('Table', TableSchema);