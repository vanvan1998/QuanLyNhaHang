const mongoose = require('mongoose');

const CustomerSchema = mongoose.Schema({
    ID: Number,
    fullName: String,
    phone: String,
}, {
        timestamps: true
    });

module.exports = mongoose.model('Customer', CustomerSchema);