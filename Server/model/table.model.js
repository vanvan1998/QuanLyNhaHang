const mongoose = require('mongoose');


var tableSchema = new mongoose.Schema({
    name: {
        type: String
    },
    description: {
        type: String
    }
});

 var table = mongoose.model('table',tableSchema);
module.exports = table;