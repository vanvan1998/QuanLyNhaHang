const mongoose = require('mongoose');

const TableSchema = mongoose.Schema({
    number: Number,
    info: String,
    status: String,
    customer: {
        fullName: String,
        phone: String,
        timeOder: Date
    }
}, {
    timestamps: true
});

module.exports = mongoose.model('Table', TableSchema);