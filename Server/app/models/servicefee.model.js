const mongoose = require('mongoose');

const ServicefeeSchema = mongoose.Schema({
    type: String,
    fee: Number
}, {
        timestamps: true
    });

module.exports = mongoose.model('Servicefee', ServicefeeSchema);