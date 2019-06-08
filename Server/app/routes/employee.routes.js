module.exports = (app) => {
    const employee = require('../controllers/employee.controller.js');

    // Create a new Employee
    app.post('/api/employees', employee.create);

    // Retrieve all Employees
    app.get('/api/employees', employee.findAll);

    // Retrieve a single Employee with employeeId
    app.get('/api/employees/:employeeId', employee.findOne);

    // Update a Employee with employeeId
    app.put('/api/employees/:employeeId', employee.update);

    // Update a Employee' password with employeeId
    app.put('/api/employees/password/:employeeId', employee.updatePassword);

    // Delete a Employee with employeeId
    app.delete('/api/employees/:employeeId', employee.delete);
}