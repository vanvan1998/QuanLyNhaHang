const mongoose = require('mongoose');

const PromotionSchema = mongoose.Schema({
    code: String,
    type: String,
    value: Number,
    rule: String
}, {
        timestamps: true
    });

module.exports = mongoose.model('Promotion', PromotionSchema);