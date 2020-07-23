const { override, fixBabelImports, addLessLoader } = require('customize-cra');
const darkThemeVars = require('antd/dist/dark-theme');

module.exports = override(
  fixBabelImports('import', {
    libraryName: 'antd',
    libraryDirectory: 'es',
    style: true,
  }),
  addLessLoader({
    javascriptEnabled: true,
    modifyVars: {
      ...darkThemeVars,
      '@primary-color': '#1da548',
      '@body-background': '#14181c',
      '@card-background': '#14181c',
    },
  }),
);
