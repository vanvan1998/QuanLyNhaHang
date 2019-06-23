const Promotion = require('../models/promotion.model.js');

// Create and Save a new Promotion
exports.create = async function (req, res) {
    try {
        var existPromotion = await Promotion.findOne({ code: req.body.code });
        if (existPromotion != null) {
            // Create a Promotion
            const promotion = new Promotion({
                code: req.body.code,
                type: req.body.type,
                value : req.body.value,
                rule: req.body.rule
            });

            // Save Promotion in the database
            promotion.save()
                .then(data => {
                    res.send({ message: "successful" });
                }).catch(err => {
                    res.send({
                        message: err.message || "Some error occurred while creating the Promotion."
                    });
                });
        }
        else{
            res.send({message: "Promotion already exists"});
        }
    } catch (error) {
        res.send({message: error});
    }
};

// Retrieve and return Promotions
exports.findAll = async (req, res) => {
    try {
        var promotion = await Promotion.find();

        if (promotion!=null){
            res.send(promotion);
        }
        else{
            res.send({message: "Promotion is not exist"});
        }
    } catch (error) {
        res.send({message: error});
    }
};