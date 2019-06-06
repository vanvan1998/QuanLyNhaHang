const mongoose = require('mongoose');

const TableSchema = mongoose.Schema({
    number: Number,
    note: String,
    status: String,
    numberOfSeat: Number,
    type: String,
<<<<<<< HEAD
    IDCustomer : mongoose.SchemaTypes.ObjectId,
=======
    customer: {
        fullName : String,
        phone:  String
    },
>>>>>>> 83b765f43db8fcd107d045c5be65dd6ddfa186c3
    time : Date
}, {
    timestamps: true
});

module.exports = mongoose.model('Table', TableSchema);