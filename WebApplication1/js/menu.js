

var menu = (function () {
    var permissionData = {
        parents: [{
            name: '系统管理',
            id: 0
        }, {
            name: '组织架构',
            id: 1
        }, {
            name: '安全检查',
            id: 2
        }, {
            name: '员工培训',
            id: 3
        }, {
            name: '在线学习',
            id: 4
        }],
        children: [
            [{
                id: 0,
                name: '自定义logo',
                checked: false,
            }, {
                id: 1,
                name: '用户权限',
                checked: false,
            }],

            [{
                id: 2,
                name: '公司（厂）',
                checked: false,
            }, {
                id: 3,
                name: '部门/项目',
                checked: false,
            }, {
                id: 4,
                name: '员工管理',
                checked: false,
            }],


            [{
                id: 5,
                name: '风险控制台',
                checked: false,
            }, {
                id: 6,
                name: '检查记录',
                checked: false,
            }, {
                id: 7,
                name: '统计',
                checked: false,
            }],

            [{
                id: 8,
                name: '试题管理',
                checked: false,
            }, {
                id: 9,
                name: '培训计划及组织',
                checked: false,
            }, {
                id: 10,
                name: '三级教育',
                checked: false,
            }],

            [{
                id: 11,
                name: '学习资料',
                checked: false,
            }, {
                id: 12,
                name: '我的教育卡',
                checked: false,
            }, {
                id: 13,
                name: '我的题库',
                checked: false,
            }, {
                id: 14,
                name: '我的错题库',
                checked: false,
            }, {
                id: 15,
                name: '统计与分析',
                checked: false,
            }],
        ]
    };
    return {
        permissionData: permissionData
    }
})();