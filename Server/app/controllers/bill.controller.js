const Bill = require('../models/bill.model.js');
const Food = require('../models/food.model.js');
const Table = require('../models/table.model.js');
const Employee = require('../models/employee.model.js');
const mongoose = require('mongoose');

// Create and Save a new Bill
exports.create = async function (req, res) {
    // Validate request
    if (!req.body.employeeID) {
        return res.send({
            message: "Bill's employeeID can not be empty"
        });
    }

    // Create a Bill
    var total = 0;
    if (req.body.type == "standard") {
        total = parseInt(req.body.numberOfSeat) * 10000;
    }
    else {
        total = parseInt(req.body.numberOfSeat) * 30000;
    }
    var count = await Bill.countDocuments({});
    const bill = new Bill({
        employeeID: req.body.employeeID,
        tableNumber: req.body.number,
        billNumber: count + 1,
        status: "unpaid",
        promotion: 0,
        total: total,
        menu: new Array(),
        customer: {
            fullName: req.body.fullName,
            phone: req.body.phone,
        }
    });

    // Save Bill in the database
    bill.save()
        .then(data => {
            res.send({ message: "successful" });
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while creating the Bill."
            });
        });
};

// Retrieve and return all bills with status and type from the database.
exports.findAll = (req, res) => {

    Bill.find({})
        .then(bills => {
            res.send(bills);
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while retrieving bills."
            });
        });
};

// Find a single bill with a billId
exports.findOne = async (req, res) => {
    var listFood = [];
    var bill = await Bill.findOne({ "tableNumber": parseInt(req.params.tableNumber), "status": "unpaid" });
    for (var foodItem of bill.menu) {
        var food = await Food.findById(foodItem.id);
        listFood.push({ name: food.name, price: food.price, amount: foodItem.amount });
    }
    res.send(listFood);
};

// Update a bill identified by the billId in the request
exports.update = (req, res) => {
    //Validate request
    if (!req.body.tableID) {
        return res.send({
            message: "Bill's tableID can not be empty"
        });
    }

    // Validate request
    if (!req.body.employeeID) {
        return res.send({
            message: "Bill's employeeID can not be empty"
        });
    }

    // Validate request
    if (!req.body.customerID) {
        return res.send({
            message: "Bill's customerID can not be empty"
        });
    }

    // Find bill and update it with the request body
    Bill.findByIdAndUpdate(req.params.billId, {
        tableID: req.body.tableID,
        employeeID: req.body.employeeID,
        customerID: req.body.customerID,
        billNumber: req.body.billNumber,
        status: req.body.status,
        promotion: req.body.promotion,
        total: req.body.total,
        menu: req.body.menu,
        time: req.body.time
    }, { new: true })
        .then(bill => {
            if (!bill) {
                return res.status(404).send({
                    message: "Bill not found with id " + req.params.billId
                });
            }
            res.send({ message: "Bill updated successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Bill not found with id " + req.params.billId
                });
            }
            return res.send({
                message: "Error updating bill with id " + req.params.billId
            });
        });
};

// Delete a bill with the specified billId in the request
exports.delete = (req, res) => {
    Bill.findByIdAndRemove(req.params.billId)
        .then(bill => {
            if (!bill) {
                return res.send({
                    message: "Bill not found with id " + req.params.billId
                });
            }
            res.send({ message: "Bill deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.send({
                    message: "Bill not found with id " + req.params.billId
                });
            }
            return res.send({
                message: "Could not delete bill with id " + req.params.billId
            });
        });
};

exports.addFoodInBill = async function (req, res) {
    // Find bill and update it with the request body
    Bill.findOne({ "tableNumber": parseInt(req.body.tableNumber), status: "unpaid" })
        .then(bill => {
            if (!bill) {
                console.log("Bill not found!!!");
            }

            Bill.findByIdAndUpdate(bill._id, {
                total: parseInt(req.body.price) + bill.total,
                $addToSet: {
                    menu:
                        { id: new mongoose.Types.ObjectId(req.body.foodId), amount: 1 }
                }
            }, { new: true })
                .then(bill => {
                    if (!bill) {
                        return res.status(404).send({
                            message: "Bill of table not found with id " + req.body.tableNumber
                        });
                    }
                    res.send({ message: "successfull" });
                }).catch(err => {
                    if (err.kind === 'ObjectId') {
                        return res.status(404).send({
                            message: "Bill not found with id " + req.body.tableNumber
                        });
                    }
                    return res.send({
                        message: "Error updating bill with id " + req.body.tableNumber
                    });
                });
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                console.log("Bill not found!!!");
            }
            console.log("Bill not found!!!");
        });

};

exports.increaseAmountFood = async function (req, res) {
    // Find bill and update it with the request body
    Bill.findOne({ "tableNumber": parseInt(req.body.tableNumber), status: "unpaid" })
        .then(bill => {
            if (!bill) {
                console.log("Bill not found!!!");
            }
            else {
                Bill.updateOne({ _id: bill._id, "menu.id": new mongoose.Types.ObjectId(req.body.foodId) }, {
                    total: parseInt(req.body.price) + bill.total,
                    $inc: { "menu.$.amount": 1 }
                }).then(bill => {
                    if (!bill) {
                        return res.status(404).send({
                            message: "Bill of table not found with id " + req.body.tableNumber
                        });
                    }
                    res.send({ message: "successfull" });
                }).catch(err => {
                    if (err.kind === 'ObjectId') {
                        return res.status(404).send({
                            message: "Bill not found with id " + req.body.tableNumber
                        });
                    }
                    return res.send({
                        message: err
                    });
                });
            }
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                console.log(err);
            }
            console.log(err);
        });

};

exports.decreaseAmountFood = async function (req, res) {
    // Find bill and update it with the request body
    Bill.findOne({ "tableNumber": parseInt(req.body.tableNumber), status: "unpaid" })
        .then(bill => {
            if (!bill) {
                console.log("Bill not found!!!");
            }
            else {
                Bill.updateOne({ _id: bill._id, "menu.id": new mongoose.Types.ObjectId(req.body.foodId) }, {
                    total: bill.total - parseInt(req.body.price),
                    $inc: { "menu.$.amount": -1 }
                }).then(bill => {
                    if (!bill) {
                        return res.status(404).send({
                            message: "Bill of table not found with id " + req.body.tableNumber
                        });
                    }
                    res.send({ message: "successfull" });
                }).catch(err => {
                    if (err.kind === 'ObjectId') {
                        return res.status(404).send({
                            message: "Bill not found with id " + req.body.tableNumber
                        });
                    }
                    return res.send({
                        message: err
                    });
                });
            }
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                console.log(err);
            }
            console.log(err);
        });

};

exports.getTotalBill = function (req, res) {
    Bill.findOne({ "tableNumber": parseInt(req.params.tableNumber), "status": "unpaid" }).then(bill => {
        if (!bill) {
            return res.send({
                message: "Bill not found with " + req.params.tableNumber
            });
        }
        res.send({ total: bill.total });
    })
};

exports.pay = function (req, res) {
    Bill.findOne({ "tableNumber": parseInt(req.body.tableNumber), "status": "unpaid" }).then(bill => {
        if (!bill) {
            return res.send({
                message: "Bill not found with " + req.body.tableNumber
            });
        }

        Bill.findByIdAndUpdate(bill._id, {
            status: "paid", promotion: req.body.promotion
        }, { new: true })
            .then(bill => {
                if (!bill) {
                    return res.status(404).send({
                        message: "Bill of table not found with id " + req.body.tableNumber
                    });
                }
                res.send({ message: "successfull" });
            }).catch(err => {
                if (err.kind === 'ObjectId') {
                    return res.status(404).send({
                        message: "Bill not found with id " + req.body.tableNumber
                    });
                }
                return res.send({
                    message: "Error updating bill with id " + req.body.tableNumber
                });
            });
    }).catch(err => {
        if (err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.send({
                message: "Bill not found with id " + req.body.tableNumber
            });
        }
        return res.send({
            message: "Could not update bill with id " + req.body.tableNumber
        });
    });

    Table.findOne({ "number": parseInt(req.body.tableNumber) }).then(table => {
        if (!table) {
            return res.send({
                message: "Table not found with " + req.params.tableNumber
            });
        }

        Table.findByIdAndUpdate(table._id, {
            status: "empty",
            note: "",
            customer: { fullName: "", phone: "" },
            time: ""
        }, { new: true })
            .then(table => {
                if (!table) {
                    return res.status(404).send({
                        message: "table not found with id " + req.body.tableNumber
                    });
                }
                res.send({ message: "successfull" });
            }).catch(err => {
                if (err.kind === 'ObjectId') {
                    return res.status(404).send({
                        message: "table not found with id " + req.body.tableNumber
                    });
                }
                return res.send({
                    message: "Error updating table with id " + req.body.tableNumber
                });
            });
    }).catch(err => {
        if (err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.send({
                message: "table not found with id " + req.body.tableNumber
            });
        }
        return res.send({
            message: "Could not update table with id " + req.body.tableNumber
        });
    });
};

exports.filter = function (req, res) {
    var startTime = req.body.startTime;
    var endTime = req.body.endTime;
    Bill.find({ "createdAt": { $gte: new Date(startTime + "T00:00:00.000Z"), $lte: new Date(endTime + "T23:59:59.999Z") }, "status": "paid" }).then(bill => {
        res.send(bill);
    })
};

exports.findOneBill = async function (req, res) {
    try {
        var bill =await Bill.findOne({ "billNumber": parseInt( req.params.billNumber) });
        res.send( bill);
    } catch (error) {
        res.send({
            message: error.message || "Some error occurred while retrieving tables."
        });
    }
};

exports.findAllWithCustomerName = async function (req, res) {
    try {
        var fullName=req.body.fullName.toUpperCase();
        var bills = await Bill.find({});
        for (i = 0; i < bills.length; i++) {
            var billsCustomer=bills[i].customer.fullName.toUpperCase();
            var check=0;
            if (billsCustomer.indexOf(fullName) != -1) {
                check=1;
            }
            else if (fullName.indexOf(billsCustomer) != -1) {
                check=1;
            }
            if(check==0)
            {
                bills.splice(i, 1);
                i--;
            }

        }
        res.send(bills);
    } catch (error) {
        res.send({
            message: error.message || "Some error occurred while retrieving bills."
        });
    }
};