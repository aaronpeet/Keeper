import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage')
  },
  {
    path: '/about/:id',
    name: 'About',
    component: loadPage('AboutPage')
  },
  {
    path: '/vault/:id',
    name: 'Vault',
    component: loadPage('VaultPage')
  },
  {
    path: '/account/:id',
    name: 'Account',
    component: loadPage('AccountPage'),
    beforeEnter: authGuard
  }

]

export const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})
