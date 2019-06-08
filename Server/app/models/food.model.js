const mongoose = require('mongoose');

const FoodSchema = mongoose.Schema({
    name: String,
    price: Number,
    ingredients: String,
    type: String,
    note: String
}, {
    timestamps: true
});

module.exports = mongoose.model('Food', FoodSchema);