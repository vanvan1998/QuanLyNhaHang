const mongoose = require('mongoose');

const CustomerSchema = mongoose.Schema({
    ID: Number,
    name: String,
    phone: String,
}, {
        timestamps: true
    });

module.exports = mongoose.model('Customer', CustomerSchema);