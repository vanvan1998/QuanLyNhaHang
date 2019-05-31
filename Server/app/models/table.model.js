const mongoose = require('mongoose');

const TableSchema = mongoose.Schema({
    number: Number,
    info: String
}, {
    timestamps: true
});

module.exports = mongoose.model('Table', TableSchema);