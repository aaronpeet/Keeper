<template>
  <button @click="createVaultKeep(state.newVaultKeep)" class="dropdown-item" type="button">
    {{ vault.name }}
  </button>
</template>

<script>
import { reactive, computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { vaultKeepsService } from '../services/VaultKeepsService'
export default {
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const keep = AppState.activeKeep
    const account = AppState.account
    const state = reactive({
      newVaultKeep: {
        keepId: keep.id,
        vaultId: props.vault.id,
        creatorId: account.id
      }
    })

    return {
      state,
      keep: computed(() => AppState.activeKeep),
      async createVaultKeep() {
        try {
          await vaultKeepsService.createVaultKeep(state.newVaultKeep)
          state.newVaultKeep = { keepId: keep.id, vaultId: props.vault.id, creatorId: account.id }
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
