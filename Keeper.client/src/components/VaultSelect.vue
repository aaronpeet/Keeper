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
    const keep = computed(() => AppState.activeKeep)
    const account = computed(() => AppState.account)
    const state = reactive({
      newVaultKeep: {}
    })

    return {
      state,
      keep,

      async createVaultKeep() {
        try {
          state.newVaultKeep = {
            keepId: keep.value.id,
            vaultId: props.vault.id,
            creatorId: account.value.id
          }
          await vaultKeepsService.createVaultKeep(state.newVaultKeep)
          state.newVaultKeep = {}
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
