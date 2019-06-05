const mongoose = require('mongoose');

const CustomerSchema = mongoose.Schema({
    fullName: String,
    phone: String,
}, {
        timestamps: true
    });

module.exports = mongoose.model('Customer', CustomerSchema);