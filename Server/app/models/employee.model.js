const mongoose = require('mongoose');

const EmployeeSchema = mongoose.Schema({
    username: String,
    password: String,
    displayName: String,
    role: String,
    dateOfBirth: String,
    identityNumber: String,
    phone: String
}, {
        timestamps: true
    });

module.exports = mongoose.model('Employee', EmployeeSchema);